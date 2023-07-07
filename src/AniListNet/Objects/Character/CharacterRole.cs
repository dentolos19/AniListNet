using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum CharacterRole
{
    /// <summary>
    /// A primary character role in the media.
    /// </summary>
    [EnumMember(Value = "MAIN")] Main,

    /// <summary>
    /// A supporting character role in the media.
    /// </summary>
    [EnumMember(Value = "SUPPORTING")] Supporting,

    /// <summary>
    /// A background character in the media.
    /// </summary>
    [EnumMember(Value = "BACKGROUND")] Background
}