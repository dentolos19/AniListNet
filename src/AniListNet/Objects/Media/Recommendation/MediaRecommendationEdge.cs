using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaRecommendationEdge
{
    [GqlSelection("node")] public MediaRecommendation Recommendation { get; private set; }
}