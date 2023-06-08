using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTrendEdge
{
    [JsonProperty("node")] public MediaTrend Node { get; set; }
}