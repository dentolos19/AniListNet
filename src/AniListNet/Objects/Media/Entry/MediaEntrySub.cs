using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntrySub
{
    [JsonProperty("media")] private readonly Media _media;

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

    /// <summary>
    /// The max possible progress of the anime or manga.
    /// </summary>
    public int? MaxProgress => _media.Episodes ?? _media.Chapters;

    /* below are properties that are not part of the API */

    /// <summary>
    /// The max possible volume progress of the manga.
    /// </summary>
    public int? MaxVolumeProgress => _media.Volumes;

    private class Media
    {
        [JsonProperty("episodes")] public int? Episodes { get; private set; }
        [JsonProperty("chapters")] public int? Chapters { get; private set; }
        [JsonProperty("volumes")] public int? Volumes { get; private set; }
    }
}