using Newtonsoft.Json;

namespace AniListNet.Objects.Recommendation;

public class RecommendationEdge
{
    [JsonProperty("node")] public Recommendation Recommendation { get; private set; }
}