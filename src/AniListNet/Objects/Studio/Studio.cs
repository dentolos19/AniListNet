using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Studio
{
    /// <summary>
    /// The ID of the studio.
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
    /// The URL for the studio page on the AniList website.
    /// </summary>
    [JsonProperty("siteUrl")] public Uri Url { get; private set; }

    /// <summary>
    /// The amount of user's who have favorited the studio.
    /// </summary>
    [JsonProperty("favourites")] public int Favorites { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the studio is marked as favorite by the currently authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }
}