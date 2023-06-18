using AniListNet.Helpers;

namespace AniListNet.Objects;

/// <summary>
/// Media list collection query, provides list pre-grouped by status & custom lists. User ID and Media Type arguments required.
/// </summary>
public class MediaListCollection
{
    /// <summary>
    /// Grouped media list entries.
    /// </summary>
    [GqlSelection("lists")] public MediaList[] Lists { get; private set; }

    /// <summary>
    /// The owner of the list.
    /// </summary>
    [GqlSelection("user")] public User User { get; private set; }

    /// <summary>
    /// If there is another chunk.
    /// </summary>
    [GqlSelection("hasNextChunk")] public bool HasNextChunk { get; private set; }
}