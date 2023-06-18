using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AniListNet.Helpers;

internal static class GqlParser
{
    private static readonly JsonSerializer JsonSerializer = new() { ContractResolver = new GqlObjectResolver() };

    public static IList<GqlSelection> ParseToSelections<TObject>()
    {
        return ParseToSelections(typeof(TObject));
    }

    public static IList<GqlSelection> ParseToSelections(Type type)
    {
        var elementType = type.GetElementType();
        if (elementType is not null)
            type = elementType;
        var properties = type.GetProperties().Cast<MemberInfo>();
        var fields = type.GetFields().Cast<MemberInfo>();
        var variables = properties.Concat(fields);
        var selections = new List<GqlSelection>();
        foreach (var variable in variables)
        {
            var selectionAttribute = variable.GetCustomAttribute<GqlSelectionAttribute>();
            if (selectionAttribute is null)
                continue;
            var subSelections = ParseToSelections(variable.MemberType switch
            {
                MemberTypes.Field => ((FieldInfo)variable).FieldType,
                MemberTypes.Property => ((PropertyInfo)variable).PropertyType
            });
            var parameters = variable.GetCustomAttributes<GqlParameterAttribute>().Select(attribute => new GqlParameter(attribute));
            var selection = new GqlSelection(selectionAttribute)
            {
                Parameters = parameters.ToList(),
                Selections = subSelections
            };
            if (!string.IsNullOrEmpty(selectionAttribute.Alias))
                selection.Alias = selectionAttribute.Alias;
            selections.Add(selection);
        }
        return selections;
    }

    public static string ParseToString(GqlSelection selection)
    {
        return ParseToString(new[] { selection });
    }

    public static string ParseToString(IEnumerable<GqlSelection> selections)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append('{');
        stringBuilder.Append(BuildSelections(selections));
        stringBuilder.Append('}');
        return stringBuilder.ToString();
    }

    public static TObject? ParseFromJson<TObject>(JToken token)
    {
        return token.ToObject<TObject>(JsonSerializer);
    }

    private static string GetEnumMemberValue(Enum @enum)
    {
        var field = @enum.GetType().GetField(@enum.ToString());
        var attribute = field?.GetCustomAttribute<EnumMemberAttribute>();
        return attribute?.Value ?? @enum.ToString();
    }

    private static string BuildSelections(IEnumerable<GqlSelection> selections)
    {
        var stringBuilder = new StringBuilder();
        foreach (var selection in selections)
        {
            stringBuilder.Append(stringBuilder.Length > 0 ? ',' : string.Empty);
            if (!string.IsNullOrEmpty(selection.Alias))
                stringBuilder.Append(selection.Alias + ":");
            stringBuilder.Append(selection.Name);
            if (selection.Parameters is { Count: > 0 })
                stringBuilder.Append($"({BuildParameters(selection.Parameters)})");
            if (selection.Selections is { Count: > 0 })
                stringBuilder.Append($"{{{BuildSelections(selection.Selections)}}}");
        }
        return stringBuilder.ToString();
    }

    private static string BuildParameters(IEnumerable<GqlParameter> parameters)
    {
        var stringBuilder = new StringBuilder();
        foreach (var parameter in parameters)
            stringBuilder.Append((stringBuilder.Length > 1 ? "," : string.Empty) + parameter.Name + ":" + ParseObjectString(parameter.Value));
        return stringBuilder.ToString();
    }

    private static string ParseObjectString(object? value)
    {
        return value switch
        {
            null => "null",
            string @string => @string.StartsWith('$') ? @string.TrimStart('$') : $"\"{@string}\"",
            bool @bool => @bool ? "true" : "false",
            Enum @enum => GetEnumMemberValue(@enum),
            IEnumerable<GqlParameter> parameters => ((Func<string>)(() =>
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append('{');
                foreach (var parameter in parameters)
                {
                    stringBuilder.Append(stringBuilder.Length > 1 ? "," : string.Empty);
                    stringBuilder.Append(parameter.Name);
                    stringBuilder.Append(":");
                    stringBuilder.Append(ParseObjectString(parameter.Value));
                }
                stringBuilder.Append('}');
                return stringBuilder.ToString();
            }))(),
            IEnumerable enumerable => ((Func<string>)(() =>
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append('[');
                foreach (var item in enumerable)
                {
                    stringBuilder.Append(stringBuilder.Length > 1 ? "," : string.Empty);
                    stringBuilder.Append(ParseObjectString(item));
                }
                stringBuilder.Append(']');
                return stringBuilder.ToString();
            }))(),
            _ => value.ToString()
        };
    }
}