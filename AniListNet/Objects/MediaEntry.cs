using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntry
{

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("status")] public MediaEntryStatus Status { get; private init; }
    [JsonProperty("score")] public float Score { get; private init; }
    [JsonProperty("progress")] public int Progress { get; private init; }
    [JsonProperty("startedAt")] public Date StartDate { get; private init; }
    [JsonProperty("completedAt")] public Date CompleteDate { get; private init; }
    [JsonProperty("media")] public Media Media { get; private init; }

    public int? MaxProgress => Media.Episodes ?? Media.Episodes;

}