using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaScheduleSort
{
    [EnumMember(Value = "TIME")] Time,
    [EnumMember(Value = "EPISODE")] Episode
}