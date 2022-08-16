using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum UserStaffNameLanguage
{

    [EnumMember(Value = "ROMAJI_WESTERN")] WesternRomaji,
    [EnumMember(Value = "ROMAJI")] Romaji,
    [EnumMember(Value = "NATIVE")] Native

}