using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// Daily media statistics.
/// </summary>
public class MediaTrend
{
    [JsonProperty("date")] public int _date { get; set; }
    
    /// <summary>
    /// The id of the tag.
    /// </summary>
    [JsonProperty("mediaId")] public int MediaId { get; set; }
    /// <summary>
    /// The amount of media activity on the day.
    /// </summary>
    [JsonProperty("trending")] public int Trending { get; set; }
    /// <summary>
    /// A weighted average score of all the user's scores of the media.
    /// </summary>
    [JsonProperty("averageScore")] public int AverageScore { get; set; }
    /// <summary>
    /// The number of users with the media on their list.
    /// </summary>
    [JsonProperty("popularity")] public int Popularity { get; set; }
    /// <summary>
    /// The number of users with watching/reading the media.
    /// </summary>
    [JsonProperty("inProgress")] public int InProgressCount { get; set; }
    /// <summary>
    /// If the media was being released at this time.
    /// </summary>
    [JsonProperty("releasing")] public bool Releasing { get; set; }
    /// <summary>
    /// The episode number of the anime released on this day.
    /// </summary>
    [JsonProperty("episode")] public int? Episode { get; set; }
    /// <summary>
    /// The related media.
    /// </summary>
    [JsonProperty("media")] public Media Media { get; set; }
    /// <summary>
    /// The day the data was recorded.
    /// </summary>
    public DateTime Date => DateTimeOffset.FromUnixTimeSeconds(_date).DateTime;


}