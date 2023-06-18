using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaStaffEdge : MediaEdge
{
    [GqlSelection("staffRole")] public string Role { get; private set; }
}