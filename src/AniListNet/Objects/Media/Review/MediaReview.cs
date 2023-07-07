using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaReview
{
    [GqlSelection("createdAt")] private readonly int _createdAt;
    [GqlSelection("updatedAt")] private readonly int _updatedAt;

    /// <summary>
    /// The ID of the review.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The creator of the review.
    /// </summary>
    [GqlSelection("user")] public User User { get; private set; }

    /// <summary>
    /// The media the review is of.
    /// </summary>
    [GqlSelection("media")] public Media Media { get; private set; }

    /// <summary>
    /// A short summary of the review.
    /// </summary>
    [GqlSelection("summary")] public string Summary { get; private set; }

    /// <summary>
    /// For which type of media the review is for.
    /// </summary>
    [GqlSelection("mediaType")] public MediaType MediaType { get; private set; }

    /// <summary>
    /// The main review body text.
    /// </summary>
    /// <remarks>In markdown format.</remarks>
    [GqlSelection("body")]
    [GqlParameter("asHtml", false)]
    public string Body { get; private set; }

    /// <summary>
    /// The main review body text.
    /// </summary>
    /// <remarks>In HTML format.</remarks>
    [GqlSelection("body", "bodyHtml")]
    [GqlParameter("asHtml", true)]
    public string BodyHtml { get; private set; }

    /// <summary>
    /// The total user rating of the review.
    /// </summary>
    [GqlSelection("rating")] public int Rating { get; private set; }

    /// <summary>
    /// The amount of user ratings of the review.
    /// </summary>
    [GqlSelection("ratingAmount")] public int RatingAmount { get; private set; }

    /// <summary>
    /// The review score of the media.
    /// </summary>
    [GqlSelection("score")] public int Score { get; private set; }

    /// <summary>
    /// The url for the review page on the AniList website.
    /// </summary>
    [GqlSelection("siteUrl")] public Uri Url { get; private set; }

    /// <summary>
    /// If the review is only be visible to its creator.
    /// </summary>
    [GqlSelection("private")] public bool IsPrivate { get; private set; }

    /// <summary>
    /// The time of the thread creation.
    /// </summary>
    public DateTime CreatedAt => DateTimeOffset.FromUnixTimeSeconds(_createdAt).DateTime;

    /// <summary>
    /// The time of the thread last update.
    /// </summary>
    public DateTime UpdatedAt => DateTimeOffset.FromUnixTimeSeconds(_updatedAt).DateTime;

    /* below are properties only for the authenticated user */

    /// <summary>
    /// The rating of the review by currently authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("userRating")] public MediaReviewRating UserRating { get; private set; }
}