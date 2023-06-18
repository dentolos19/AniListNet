using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaStudioEdge : MediaEdge
{
    [GqlSelection("isMainStudio")] public bool IsMainStudio { get; private set; }
}