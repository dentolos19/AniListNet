using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaCharacterEdge : MediaEdge
{
    /// <summary>
    /// The character's role in the media.
    /// </summary>
    [GqlSelection("characterRole")] public string Role { get; private set; }
}