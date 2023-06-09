using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaStatus
{
    /// <summary>
    /// Has completed and is no longer being released.
    /// </summary>
    [EnumMember(Value = "FINISHED")] Finished,

    /// <summary>
    /// Currently releasing.
    /// </summary>
    [EnumMember(Value = "RELEASING")] Releasing,

    /// <summary>
    /// To be released at a later date.
    /// </summary>
    [EnumMember(Value = "NOT_YET_RELEASED")] NotYetReleased,

    /// <summary>
    /// Ended before the work could be finished.
    /// </summary>
    [EnumMember(Value = "CANCELLED")] Canceled,

    /// <summary>
    /// Is currently paused from releasing and will resume at a later date.
    /// </summary>
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "HIATUS")] Hiatus // v2
}