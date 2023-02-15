using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaStatus
{
    [EnumMember(Value = "FINISHED")] Finished,
    [EnumMember(Value = "RELEASING")] Releasing,
    [EnumMember(Value = "NOT_YET_RELEASED")] NotYetReleased,
    [EnumMember(Value = "CANCELLED")] Canceled,
    [EnumMember(Value = "HIATUS")] Hiatus // v2
}