using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Studio
{
    /// <summary>
    /// The id of the studio.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The name of the studio.
    /// </summary>
    [JsonProperty("name")] public string Name { get; private set; }
    /// <summary>
    /// If the studio is an animation studio or a different kind of company.
    /// </summary>
    [JsonProperty("isAnimationStudio")] public bool IsAnimationStudio { get; private set; }
    /// <summary>
    /// The amount of user's who have favorite the studio.
    /// </summary>
    [JsonProperty("favourites")] public int Favorites { get; private set; }
    /// <summary>
    /// The url for the studio page on the AniList website.
    /// </summary>
    [JsonProperty("siteUrl")] public Uri Url { get; private set; }

    /* below are properties specific for the authenticated user */
    /// <summary>
    /// If the studio is marked as favourite by the currently authenticated user.
    /// </summary>
    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }
}