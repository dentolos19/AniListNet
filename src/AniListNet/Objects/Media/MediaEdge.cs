using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaEdge
{
    [GqlSelection("node")] public Media Media { get; private set; }
    [GqlSelection("id")] public string Id { get; private set; }
}