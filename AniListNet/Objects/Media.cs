using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Media
{

    [JsonProperty("duration")] private readonly int? _duration;

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("idMal")] public int? MalId { get; private init; }
    [JsonProperty("title")] public MediaTitle Title { get; private init; }
    [JsonProperty("type")] public MediaType Type { get; private init; }
    [JsonProperty("format")] public MediaFormat? Format { get; private init; }
    [JsonProperty("status")] [GqlParameter("version", 2)] public MediaStatus Status { get; private init; }
    [JsonProperty("description")] public string? Description { get; private init; }
    [JsonProperty("startDate")] public Date StartDate { get; private init; }
    [JsonProperty("endDate")] public Date EndDate { get; private init; }
    [JsonProperty("season")] public MediaSeason? Season { get; private init; }
    [JsonProperty("seasonYear")] public int? SeasonYear { get; private init; }
    [JsonProperty("episodes")] public int? Episodes { get; private init; }
    [JsonProperty("chapters")] public int? Chapters { get; private init; }
    [JsonProperty("volumes")] public int? Volumes { get; private init; }
    [JsonProperty("source")] [GqlParameter("version", 3)] public MediaSource? Source { get; private init; }
    [JsonProperty("coverImage")] public Cover Cover { get; private init; }
    [JsonProperty("bannerImage")] public Uri? BannerImageUrl { get; private init; }
    [JsonProperty("genres")] public string[] Genres { get; private init; }
    [JsonProperty("synonyms")] public string[] Synonyms { get; private init; }
    [JsonProperty("averageScore")] public int? AverageScore { get; private init; }
    [JsonProperty("meanScore")] public int? MeanScore { get; private init; }
    [JsonProperty("popularity")] public int Popularity { get; private init; }
    [JsonProperty("favourites")] public int Favorites { get; private init; }
    // [JsonProperty("tags")] public MediaTag[] Tags { get; private init; }
    [JsonProperty("isAdult")] public bool IsAdult { get; private init; }

    public TimeSpan? Duration => _duration.HasValue ? new TimeSpan(0, _duration.Value, 0) : null;

    /* below is properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private init; }

}