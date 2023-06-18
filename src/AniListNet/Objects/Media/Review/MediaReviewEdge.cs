using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaReviewEdge
{
    [GqlSelection("node")] public MediaReview Review { get; private set; }
}