using System.Collections;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace AniListNet.Helpers;

internal static class GqlParser
{

    public static string ParseSelections(GqlSelection selection)
    {
        return ParseSelections(new[] { selection });
    }

    public static string ParseSelections(IEnumerable<GqlSelection> selections)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append('{');
        stringBuilder.Append(BuildSelections(selections));
        stringBuilder.Append('}');
        return stringBuilder.ToString();
    }

    public static IList<GqlSelection> ParseType(Type type)
    {
        var elementType = type.GetElementType();
        if (elementType != null)
            type = elementType;
        var selections = new List<GqlSelection>();
        var variables = type.GetProperties().Cast<MemberInfo>().Concat(type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance));
        foreach (var variable in variables)
        {
            var jsonAttribute = variable.GetCustomAttribute<JsonPropertyAttribute>();
            if (jsonAttribute == null)
                continue;
            var subSelections = ParseType(variable.MemberType switch
            {
                MemberTypes.Field => ((FieldInfo)variable).FieldType,
                MemberTypes.Property => ((PropertyInfo)variable).PropertyType
            });
            var parameters = variable.GetCustomAttributes<GqlParameterAttribute>().Select(attribute => attribute.Parameter).ToArray();
            selections.Add(new GqlSelection(jsonAttribute.PropertyName ?? variable.Name, subSelections, parameters));
        }
        return selections;
    }

    private static string BuildSelections(IEnumerable<GqlSelection> selections)
    {
        var stringBuilder = new StringBuilder();
        foreach (var selection in selections)
        {
            stringBuilder.Append((stringBuilder.Length > 0 ? ',' : string.Empty) + selection.Name);
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

    private static string? ParseObjectString(object? value)
    {
        return value switch
        {
            null => "null",
            string @string => @string.StartsWith("$") ? @string.TrimStart('$') : $"\"{@string}\"",
            bool @bool => @bool ? "true" : "false",
            Enum @enum => HelperUtilities.GetEnumMemberValue(@enum),
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
                stringBuilder.Append("}");
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