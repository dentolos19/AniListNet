using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace AniListNet.Helpers;

internal static class GqlParser
{

    public static string ParseSelections(GqlSelection[] selections)
    {
        return $"{{{BuildSelections(selections)}}}";
    }

    public static GqlSelection[] ParseType(Type type)
    {
        var elementType = type.GetElementType();
        if (elementType != null)
            type = elementType;
        var properties = type.GetProperties();
        var selections = new List<GqlSelection>();
        foreach (var property in properties)
        {
            var jsonAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            if (jsonAttribute == null)
                continue;
            var subSelections = ParseType(property.PropertyType);
            var parameters = property.GetCustomAttributes<GqlParameterAttribute>().Select(attribute => attribute.Parameter).ToArray();
            selections.Add(new GqlSelection(jsonAttribute.PropertyName, subSelections, parameters));
        }
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