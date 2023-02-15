using System.Reflection;
using System.Runtime.Serialization;

namespace AniListNet.Helpers;

internal static class HelperUtilities
{
    public static string GetEnumMemberValue(Enum @enum)
    {
        var field = @enum.GetType().GetField(@enum.ToString());
        var attribute = field?.GetCustomAttribute<EnumMemberAttribute>();
        return attribute?.Value ?? @enum.ToString();
    }
}