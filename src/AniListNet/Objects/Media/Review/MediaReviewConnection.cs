using Newtonsoft.Json;

namespace AniListNet.Objects;


public class MediaReviewConnection
{
    [JsonProperty("edges")] public MediaReviewEdge[] Edges { get; private set; }
    [JsonProperty("nodes")] public MediaReview[] Nodes { get; private set; }
}