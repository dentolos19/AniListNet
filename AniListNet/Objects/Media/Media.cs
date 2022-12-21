using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Media
{

    [JsonProperty("duration")] private readonly int? _duration;

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("idMal")] public int? MalId { get; private set; }
    [JsonProperty("title")] public MediaTitle Title { get; private set; }
    [JsonProperty("type")] public MediaType Type { get; private set; }
    [JsonProperty("format")] public MediaFormat? Format { get; private set; }

    [JsonProperty("status")] [GqlParameter("version", 2)]
    public MediaStatus Status { get; private set; }

    [JsonProperty("description")] public string? Description { get; private set; }
    [JsonProperty("startDate")] public Date StartDate { get; private set; }
    [JsonProperty("endDate")] public Date EndDate { get; private set; }
    [JsonProperty("season")] public MediaSeason? Season { get; private set; }
    [JsonProperty("seasonYear")] public int? SeasonYear { get; private set; }
    [JsonProperty("episodes")] public int? Episodes { get; private set; }
    [JsonProperty("chapters")] public int? Chapters { get; private set; }
    [JsonProperty("volumes")] public int? Volumes { get; private set; }

    [JsonProperty("source")] [GqlParameter("version", 3)]
    public MediaSource? Source { get; private set; }

    [JsonProperty("coverImage")] public MediaCover Cover { get; private set; }
    [JsonProperty("bannerImage")] public Uri? BannerImageUrl { get; private set; }
    [JsonProperty("genres")] public IReadOnlyList<string> Genres { get; private set; }
    [JsonProperty("synonyms")] public IReadOnlyList<string> Synonyms { get; private set; }
    [JsonProperty("averageScore")] public int? AverageScore { get; private set; }
    [JsonProperty("meanScore")] public int? MeanScore { get; private set; }
    [JsonProperty("popularity")] public int Popularity { get; private set; }
    [JsonProperty("favourites")] public int Favorites { get; private set; }
    [JsonProperty("isAdult")] public bool IsAdult { get; private set; }

    public TimeSpan? Duration => _duration.HasValue ? new TimeSpan(0, _duration.Value, 0) : null;

    /* below are properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }
    [JsonProperty("mediaListEntry")] public MediaEntrySub? Entry { get; private set; }

}