using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// Media list collection query, provides list pre-grouped by status & custom lists. User ID and Media Type arguments required.
/// </summary>
public class MediaListCollection
{
    /// <summary>
    /// Grouped media list entries.
    /// </summary>
    [JsonProperty("lists")] public MediaList[] Lists { get; private set; }

    /// <summary>
    /// The owner of the list.
    /// </summary>
    [JsonProperty("user")] public User User { get; private set; }

    /// <summary>
    /// If there is another chunk.
    /// </summary>
    [JsonProperty("hasNextChunk")] public bool HasNextChunk { get; private set; }
}