using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum UserMediaTitleLanguage
{
    [EnumMember(Value = "ROMAJI")] Romaji,
    [EnumMember(Value = "ENGLISH")] English,
    [EnumMember(Value = "NATIVE")] Native,

    [EnumMember(Value = "ROMAJI_STYLISED")]
    StylizedRomaji,

    [EnumMember(Value = "ENGLISH_STYLISED")]
    StylizedEnglish,

    [EnumMember(Value = "NATIVE_STYLISED")]
    StylizedNative
}