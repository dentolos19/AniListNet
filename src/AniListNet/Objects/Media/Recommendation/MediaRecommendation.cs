using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaRecommendation
{
    /// <summary>
    /// The ID of the recommendation.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// Users rating of the recommendation.
    /// </summary>
    [GqlSelection("rating")] public int Rating { get; private set; }

    /// <summary>
    /// The media the recommendation is from.
    /// </summary>
    [GqlSelection("media")] public Media Media { get; private set; }

    /// <summary>
    /// The recommended media.
    /// </summary>
    [GqlSelection("mediaRecommendation")] public Media Recommendation { get; private set; }

    /// <summary>
    /// The user that first created the recommendation.
    /// </summary>
    [GqlSelection("user")] public User User { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// The rating of the recommendation by currently authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("userRating")] public MediaRecommendationRating UserRating { get; private set; }
}