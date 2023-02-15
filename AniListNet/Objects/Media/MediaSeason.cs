using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaSeason
{
    [EnumMember(Value = "WINTER")] Winter,
    [EnumMember(Value = "SPRING")] Spring,
    [EnumMember(Value = "SUMMER")] Summer,
    [EnumMember(Value = "FALL")] Fall
}