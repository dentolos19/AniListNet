using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaCharacterEdge
{
    [GqlSelection("node")] public Media Media { get; private set; }
    [GqlSelection("id")] public string Id { get; private set; }
    [GqlSelection("characterRole")] public string Role { get; private set; }
}