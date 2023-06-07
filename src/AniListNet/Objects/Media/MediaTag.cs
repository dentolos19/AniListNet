using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// A tag that describes a theme or element of the media.
/// </summary>
public class MediaTag
{
    /// <summary>
    /// The id of the tag.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The name of the tag.
    /// </summary>
    [JsonProperty("name")] public string Name { get; private set; }
    /// <summary>
    /// A general description of the tag.
    /// </summary>
    [JsonProperty("description")] public string Description { get; private set; }
    /// <summary>
    /// The categories of tags this tag belongs to.
    /// </summary>
    [JsonProperty("category")] public string Category { get; private set; }
    /// <summary>
    /// The relevance ranking of the tag out of the 100 for this media.
    /// </summary>
    [JsonProperty("rank")] public int Rank { get; private set; }
    /// <summary>
    /// If the tag could be a spoiler for any media.
    /// </summary>
    [JsonProperty("isGeneralSpoiler")] public bool IsGeneralSpoiler { get; private set; }
    /// <summary>
    /// If the tag is a spoiler for this media.
    /// </summary>
    [JsonProperty("isMediaSpoiler")] public bool IsMediaSpoiler { get; private set; }
    /// <summary>
    /// If the tag is only for adult 18+ media.
    /// </summary>
    [JsonProperty("isAdult")] public bool IsAdult { get; private set; }
}