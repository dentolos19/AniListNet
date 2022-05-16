using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaRelation
{

    [EnumMember(Value = "ADPATION")] Adaption,
    [EnumMember(Value = "PREQUEL")] Prequel,
    [EnumMember(Value = "SEQUEL")] Sequel,
    [EnumMember(Value = "PARENT")] Parent,
    [EnumMember(Value = "SIDE_STORY")] SideStory,
    [EnumMember(Value = "CHARACTER")] Character,
    [EnumMember(Value = "SUMMARY")] Summary,
    [EnumMember(Value = "ALTERNATIVE")] Alternative,
    [EnumMember(Value = "SPIN_OFF")] SpinOff,
    [EnumMember(Value = "OTHER")] Other,
    [EnumMember(Value = "SOURCE")] Source, // v2
    [EnumMember(Value = "COMPILATION")] Compilation, // v2
    [EnumMember(Value = "CONTAINS")] Contains // v2

}