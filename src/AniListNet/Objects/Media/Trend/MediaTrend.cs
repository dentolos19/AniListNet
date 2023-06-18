using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// Daily media statistics.
/// </summary>
public class MediaTrend
{
    [GqlSelection("date")] public readonly int _date;

    /// <summary>
    /// The ID of the tag.
    /// </summary>
    [GqlSelection("mediaId")] public int MediaId { get; private set; }

    /// <summary>
    /// The day the data was recorded.
    /// </summary>
    public DateTime Date => DateTimeOffset.FromUnixTimeSeconds(_date).DateTime;

    /// <summary>
    /// The amount of media activity on the day.
    /// </summary>
    [GqlSelection("trending")] public int Trending { get; private set; }

    /// <summary>
    /// A weighted average score of all the user's scores of the media.
    /// </summary>
    [GqlSelection("averageScore")] public int AverageScore { get; private set; }

    /// <summary>
    /// The number of users with the media on their list.
    /// </summary>
    [GqlSelection("popularity")] public int Popularity { get; private set; }

    /// <summary>
    /// The number of users with watching/reading the media.
    /// </summary>
    [GqlSelection("inProgress")] public int InProgressCount { get; private set; }

    /// <summary>
    /// If the media was being released at this time.
    /// </summary>
    [GqlSelection("releasing")] public bool IsReleasing { get; private set; }

    /// <summary>
    /// The episode number of the anime released on this day.
    /// </summary>
    [GqlSelection("episode")] public int? Episode { get; private set; }

    /// <summary>
    /// The related media.
    /// </summary>
    [GqlSelection("media")] public Media Media { get; private set; }
}