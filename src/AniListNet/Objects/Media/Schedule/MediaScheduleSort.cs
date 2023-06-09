using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaScheduleSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "MEDIA_ID")] MediaId,
    [EnumMember(Value = "TIME")] Time,
    [EnumMember(Value = "EPISODE")] Episode
}