using AniListNet.Helpers;

namespace AniListNet.Objects;

public class CharacterEdge
{
    [GqlSelection("node")] public Character Character { get; private set; }
    [GqlSelection("id")] public int Id { get; private set; }
    [GqlSelection("role")] public CharacterRole Role { get; private set; }
}