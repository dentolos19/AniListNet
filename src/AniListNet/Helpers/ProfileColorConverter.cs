using AniListNet.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AniListNet.Helpers;

public class ProfileColorConverter : StringEnumConverter
{
    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var value = (string) reader.Value!;
        var enumType = Nullable.GetUnderlyingType(objectType) ?? objectType;
        var names = Enum.GetNames(enumType);

        // Check if the value matches any defined enum value
        return names.Contains(value, StringComparer.OrdinalIgnoreCase) ? Enum.Parse(enumType, value, true) : UserProfileColor.Custom;
    }
}