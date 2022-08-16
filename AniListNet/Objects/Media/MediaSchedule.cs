using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaSchedule
{

    [JsonProperty("airingAt")] private readonly int _airingAt;

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("episode")] public int Episode { get; private set; }
    [JsonProperty("media")] public Media Media { get; private set; }

    public DateTime AiringTime => DateTimeOffset.FromUnixTimeSeconds(_airingAt).DateTime;

}