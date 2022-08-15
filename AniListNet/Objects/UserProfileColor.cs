using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum UserProfileColor
{

    [EnumMember(Value = "blue")] Blue,
    [EnumMember(Value = "purple")] Purple,
    [EnumMember(Value = "pink")] Pink,
    [EnumMember(Value = "orange")] Orange,
    [EnumMember(Value = "red")] Red,
    [EnumMember(Value = "green")] Green,
    [EnumMember(Value = "gray")] Gray

}