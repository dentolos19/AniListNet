using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace AniListNet.Helpers;

internal static class GqlParser
{

    public static string ParseSelection(GqlSelection selection)
    {
        return ParseSelections(new[] { selection });
    }

    public static string ParseSelections(GqlSelection[] selections)
    {
        return $"{{{BuildSelections(selections)}}}";
    }

    public static GqlSelection[] ParseType(Type type)
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
            selections.Add(new GqlSelection(jsonAttribute.PropertyName, subSelections, parameters));
        }
        /*
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var jsonAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            if (jsonAttribute == null)
                continue;
            var subSelections = ParseType(property.PropertyType);
            var parameters = property.GetCustomAttributes<GqlParameterAttribute>().Select(attribute => attribute.Parameter).ToArray();
            selections.Add(new GqlSelection(jsonAttribute.PropertyName, subSelections, parameters));
        }
        var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            var jsonAttribute = field.GetCustomAttribute<JsonPropertyAttribute>();
            if (jsonAttribute == null)
                continue;
            var subSelections = ParseType(field.FieldType);
            var parameters = field.GetCustomAttributes<GqlParameterAttribute>().Select(attribute => attribute.Parameter).ToArray();
            selections.Add(new GqlSelection(jsonAttribute.PropertyName, subSelections, parameters));
        }
        */
        return selections.ToArray();
    }

    private static string BuildSelections(GqlSelection[] selections)
    {
        var stringBuilder = new StringBuilder();
        var isFirst = true;
        foreach (var selection in selections)
        {
            stringBuilder.Append((isFirst ? string.Empty : ",") + selection.Name);
            if (selection.Parameters is { Length: > 0 })
                stringBuilder.Append($"({BuildParameters(selection.Parameters)})");
            if (selection.Selections is { Length: > 0 })
                stringBuilder.Append($"{{{BuildSelections(selection.Selections)}}}");
            isFirst = false;
        }
        return stringBuilder.ToString();
    }

    private static string BuildParameters(GqlParameter[] parameters)
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
            Enum @enum => GetEnumValue(@enum),
            IEnumerable enumerable => ParseEnumerableString(enumerable),
            _ => value.ToString()
        };
    }

    private static string ParseEnumerableString(IEnumerable value)
    {
        var stringBuilder = new StringBuilder("[");
        var isFirst = true;
        foreach (var item in value)
        {
            stringBuilder.Append((isFirst ? string.Empty : ",") + ParseObjectString(item));
            isFirst = false;
        }
        return stringBuilder.Append("]").ToString();
    }

    private static string GetEnumValue(Enum @enum)
    {
        var field = @enum.GetType().GetField(@enum.ToString());
        var attributes = (EnumMemberAttribute[])field.GetCustomAttributes(typeof(EnumMemberAttribute), false);
        return attributes.Length > 0 ? attributes.First().Value : @enum.ToString();
    }

}