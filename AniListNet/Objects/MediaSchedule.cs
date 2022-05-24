using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaSchedule
{

    [JsonProperty("airingAt")] private readonly int _airingAt;

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("episode")] public int Episode { get; private init; }
    [JsonProperty("media")] public Media Media { get; private init; }

    public DateTime AiringTime => DateTimeOffset.FromUnixTimeSeconds(_airingAt).DateTime;

}