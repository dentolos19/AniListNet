using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaRecommendationEdge
{
    [JsonProperty("node")] public MediaRecommendation Recommendation { get; private set; }
}