using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// A Review that features in an anime or manga.
/// </summary>
public class MediaReview
{
    /// <summary>
    /// The id of the review.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The creator of the review.
    /// </summary>
    [JsonProperty("user")] public User User { get; private set; }
    /// <summary>
    /// The media the review is of.
    /// </summary>
    [JsonProperty("media")] public Media Media { get; private set; }
    /// <summary>
    /// A short summary of the review.
    /// </summary>
    [JsonProperty("summary")] public string Summary { get; private set; }
    /// <summary>
    /// For which type of media the review is for.
    /// </summary>
    [JsonProperty("mediaType")] public MediaType MediaType { get; private set; }
    /// <summary>
    /// The main review body text.
    /// </summary>
    [JsonProperty("body")] [GqlParameter("asHtml", false)] public string Body { get; private set; }
    /// <summary>
    /// The total user rating of the review.
    /// </summary>
    [JsonProperty("rating")] public int Rating { get; private set; }
    /// <summary>
    /// The amount of user ratings of the review.
    /// </summary>
    [JsonProperty("ratingAmount")] public int RatingAmount { get; private set; }
    /// <summary>
    /// The review score of the media.
    /// </summary>
    [JsonProperty("score")] public int Score { get; private set; }
    /// <summary>
    /// The url for the review page on the AniList website.
    /// </summary>
    [JsonProperty("siteUrl")] public Uri Url { get; private set; }

    [JsonProperty("createdAt")] private readonly int _createdAt;
    /// <summary>
    /// The time of the thread creation.
    /// </summary>
    public DateTime CreatedAt => DateTimeOffset.FromUnixTimeSeconds(_createdAt).DateTime;
    
    [JsonProperty("updatedAt")] private readonly int _updatedAt;
    /// <summary>
    /// The time of the thread last update.
    /// </summary>
    public DateTime UpdatedAt => DateTimeOffset.FromUnixTimeSeconds(_updatedAt).DateTime;

    
    /* below are properties specific for the authenticated user */
    
    /// <summary>
    /// The rating of the review by currently authenticated user.
    /// </summary>
    [JsonProperty("userRating")] public MediaReviewRating UserRating { get; private set; }
    
}
