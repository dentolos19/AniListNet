using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntry
{
    /// <summary>
    /// The ID of the list entry.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The watching/reading status.
    /// </summary>
    [JsonProperty("status")] public MediaEntryStatus Status { get; private set; }
    /// <summary>
    /// The score of the entry.
    /// </summary>
    [JsonProperty("score")] public float Score { get; private set; }
    /// <summary>
    /// The amount of episodes/chapters consumed by the user.
    /// </summary>
    [JsonProperty("progress")] public int Progress { get; private set; }
    /// <summary>
    /// The amount of volumes read by the user.
    /// </summary>
    [JsonProperty("progressVolumes")] public int? VolumeProgress { get; private set; }
    /// <summary>
    /// When the entry was started by the user.
    /// </summary>
    [JsonProperty("startedAt")] public Date StartDate { get; private set; }
    /// <summary>
    /// When the entry was completed by the user.
    /// </summary>
    [JsonProperty("completedAt")] public Date CompleteDate { get; private set; }
    [JsonProperty("media")] public Media Media { get; private set; }

    public int? MaxProgress => Media.Episodes ?? Media.Chapters;
    public int? MaxVolumeProgress => Media.Volumes;
}