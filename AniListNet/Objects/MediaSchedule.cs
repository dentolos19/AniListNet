using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaSchedule
{

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("airingAt")] public int AiringAt { get; private init; }
    [JsonProperty("timeUntilAiring")] public int TimeUntilAiring { get; private init; }
    [JsonProperty("episode")] public int Episode { get; private init; }
    [JsonProperty("media")] public Media Media { get; private init; }

}