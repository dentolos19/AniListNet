using System.Runtime.Serialization;

namespace AniListNet.Objects;

/// <summary>
/// The role the character plays in the media.
/// </summary>
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