using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaReviewEdge
{
    [JsonProperty("node")] public MediaReview Review { get; private set; }
}