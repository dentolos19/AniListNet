using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTrendConnection
{
    [JsonProperty("edges")] public MediaTrendEdge[] Edges { get; set; }
    [JsonProperty("nodes")] public MediaTrend[] Nodes { get; set; }
}