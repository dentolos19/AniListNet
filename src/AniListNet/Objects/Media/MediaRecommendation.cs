using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaRecommendation
{
    /// <summary>
    /// The ID of the recommendation.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// Users rating of the recommendation.
    /// </summary>
    [JsonProperty("rating")] public int Rating { get; private set; }
    /// <summary>
    /// The media the recommendation is from.
    /// </summary>
    [JsonProperty("media")] public Media Media { get; private set; }
    /// <summary>
    /// The recommended media.
    /// </summary>
    [JsonProperty("mediaRecommendation")] public Media Recommendation { get; private set; }
    /// <summary>
    /// The user that first created the recommendation.
    /// </summary>
    [JsonProperty("user")] public User User { get; private set; }

    /* below are properties specific for the authenticated user */

    /// <summary>
    /// The rating of the recommendation by currently authenticated user.
    /// </summary>
    [JsonProperty("userRating")] public MediaRecommendationRating UserRating { get; private set; }
}