using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntrySub
{
    [JsonProperty("media")] private readonly Media _media;

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("status")] public MediaEntryStatus Status { get; private set; }
    [JsonProperty("score")] public float Score { get; private set; }
    [JsonProperty("progress")] public int Progress { get; private set; }
    [JsonProperty("progressVolumes")] public int? VolumeProgress { get; private set; }
    [JsonProperty("startedAt")] public Date StartDate { get; private set; }
    [JsonProperty("completedAt")] public Date CompleteDate { get; private set; }

    public int? MaxProgress => _media.Episodes ?? _media.Chapters;
    public int? MaxVolumeProgress => _media.Volumes;

    private class Media
    {
        [JsonProperty("episodes")] public int? Episodes { get; private set; }
        [JsonProperty("chapters")] public int? Chapters { get; private set; }
        [JsonProperty("volumes")] public int? Volumes { get; private set; }
    }
}