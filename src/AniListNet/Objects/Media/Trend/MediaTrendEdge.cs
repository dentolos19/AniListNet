using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaTrendEdge
{
    [GqlSelection("node")] public MediaTrend Node { get; private set; }
}