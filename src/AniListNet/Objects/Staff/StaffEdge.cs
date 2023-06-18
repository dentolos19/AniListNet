using AniListNet.Helpers;

namespace AniListNet.Objects;

public class StaffEdge
{
    [GqlSelection("node")] public Staff Staff { get; private set; }
    [GqlSelection("id")] public int Id { get; private set; }
    [GqlSelection("role")] public string Role { get; private set; }
}