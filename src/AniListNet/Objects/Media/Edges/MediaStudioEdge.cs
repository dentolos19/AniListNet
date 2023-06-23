using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaStudioEdge : MediaEdge
{
    /// <summary>
    /// If the studio is the main animation studio of the media.
    /// </summary>
    [GqlSelection("isMainStudio")] public bool IsMainStudio { get; private set; }
}