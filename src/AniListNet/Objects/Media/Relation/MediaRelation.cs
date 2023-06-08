using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaRelation
{
    /// <summary>
    /// An adaption of this media into a different format.
    /// </summary>
    [EnumMember(Value = "ADAPTATION")] Adaption,
    /// <summary>
    /// Released before the relation.
    /// </summary>
    [EnumMember(Value = "PREQUEL")] Prequel,
    /// <summary>
    /// Released after the relation.
    /// </summary>
    [EnumMember(Value = "SEQUEL")] Sequel,
    /// <summary>
    /// The media a side story is from.
    /// </summary>
    [EnumMember(Value = "PARENT")] Parent,
    /// <summary>
    /// A side story of the parent media.
    /// </summary>
    [EnumMember(Value = "SIDE_STORY")] SideStory,
    /// <summary>
    /// Shares at least 1 character.
    /// </summary>
    [EnumMember(Value = "CHARACTER")] Character,
    /// <summary>
    /// A shortened and summarized version.
    /// </summary>
    [EnumMember(Value = "SUMMARY")] Summary,
    /// <summary>
    /// An alternative version of the same media.
    /// </summary>
    [EnumMember(Value = "ALTERNATIVE")] Alternative,
    /// <summary>
    /// An alternative version of the media with a different primary focus.
    /// </summary>
    [EnumMember(Value = "SPIN_OFF")] SpinOff,
    /// <summary>
    /// Other.
    /// </summary>
    [EnumMember(Value = "OTHER")] Other,
    /// <summary>
    /// The source material the media was adapted from.
    /// </summary>
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "SOURCE")] Source,
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "COMPILATION")] Compilation,
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "CONTAINS")] Contains
}