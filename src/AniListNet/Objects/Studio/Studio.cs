using AniListNet.Helpers;

namespace AniListNet.Objects;

public class Studio
{
    /// <summary>
    /// The ID of the studio.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The name of the studio.
    /// </summary>
    [GqlSelection("name")] public string Name { get; private set; }

    /// <summary>
    /// If the studio is an animation studio or a different kind of company.
    /// </summary>
    [GqlSelection("isAnimationStudio")] public bool IsAnimationStudio { get; private set; }

    /// <summary>
    /// The URL for the studio page on the AniList website.
    /// </summary>
    [GqlSelection("siteUrl")] public Uri Url { get; private set; }

    /// <summary>
    /// The amount of user's who have favorited the studio.
    /// </summary>
    [GqlSelection("favourites")] public int Favorites { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the studio is marked as favorite by the currently authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("isFavourite")] public bool IsFavorite { get; private set; }
}