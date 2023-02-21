using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaFormat
{
    [EnumMember(Value = "TV")] TV,
    [EnumMember(Value = "TV_SHORT")] TVShort,
    [EnumMember(Value = "MOVIE")] Movie,
    [EnumMember(Value = "SPECIAL")] Special,
    [EnumMember(Value = "OVA")] OVA,
    [EnumMember(Value = "ONA")] ONA,
    [EnumMember(Value = "MUSIC")] Music,
    [EnumMember(Value = "MANGA")] Manga,
    [EnumMember(Value = "NOVEL")] Novel,
    [EnumMember(Value = "ONE_SHOT")] OneShot
}