using AniListNet.Helpers;

namespace AniListNet.Objects;

/// <summary>
/// A tag that describes a theme or element of the media.
/// </summary>
public class MediaTag
{
    /// <summary>
    /// The ID of the tag.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The name of the tag.
    /// </summary>
    [GqlSelection("name")] public string Name { get; private set; }

    /// <summary>
    /// A general description of the tag.
    /// </summary>
    [GqlSelection("description")] public string Description { get; private set; }

    /// <summary>
    /// The categories of tags this tag belongs to.
    /// </summary>
    [GqlSelection("category")] public string Category { get; private set; }

    /// <summary>
    /// The relevance ranking of the tag out of the 100 for this media.
    /// </summary>
    [GqlSelection("rank")] public int? Rank { get; private set; }

    /// <summary>
    /// If the tag could be a spoiler for any media.
    /// </summary>
    [GqlSelection("isGeneralSpoiler")] public bool IsGeneralSpoiler { get; private set; }

    /// <summary>
    /// If the tag is a spoiler for this media.
    /// </summary>
    [GqlSelection("isMediaSpoiler")] public bool IsMediaSpoiler { get; private set; }

    /// <summary>
    /// If the tag is only for adult 18+ media.
    /// </summary>
    [GqlSelection("isAdult")] public bool IsAdult { get; private set; }
}