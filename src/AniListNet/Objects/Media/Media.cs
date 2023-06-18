using AniListNet.Helpers;

namespace AniListNet.Objects;

public class Media
{
    [GqlSelection("duration")] private readonly int? _duration;
    [GqlSelection("updatedAt")] private readonly int _updatedAt;

    /// <summary>
    /// The ID of the media.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The MyAnimeList ID of the media.
    /// </summary>
    [GqlSelection("idMal")] public int? MalId { get; private set; }

    /// <summary>
    /// The official titles of the media in various languages.
    /// </summary>
    [GqlSelection("title")] public MediaTitle Title { get; private set; }

    /// <summary>
    /// The type of the media.
    /// </summary>
    [GqlSelection("type")] public MediaType Type { get; private set; }

    /// <summary>
    /// The format the media was released in.
    /// </summary>
    [GqlSelection("format")] public MediaFormat? Format { get; private set; }

    /// <summary>
    /// The current releasing status of the media.
    /// </summary>
    [GqlSelection("status")] [GqlParameter("version", 2)] public MediaStatus? Status { get; private set; }

    /// <summary>
    /// Short description of the media's story and characters.
    /// </summary>
    /// <remarks>In markdown format.</remarks>
    [GqlSelection("description")]
    [GqlParameter("asHtml", false)]
    public string? Description { get; private set; }

    /// <summary>
    /// Short description of the media's story and characters.
    /// </summary>
    /// <remarks>In HTML format.</remarks>
    [GqlSelection("description", "descriptionHtml")]
    [GqlParameter("asHtml", true)]
    public string? DescriptionHtml { get; private set; }

    /// <summary>
    /// The first official release date of the media.
    /// </summary>
    [GqlSelection("startDate")] public Date StartDate { get; private set; }

    /// <summary>
    /// The last official release date of the media.
    /// </summary>
    [GqlSelection("endDate")] public Date EndDate { get; private set; }

    /// <summary>
    /// The season the media was initially released in.
    /// </summary>
    [GqlSelection("season")] public MediaSeason? Season { get; private set; }

    /// <summary>
    /// The season year the media was initially released in.
    /// </summary>
    [GqlSelection("seasonYear")] public int? SeasonYear { get; private set; }

    /// <summary>
    /// The amount of episodes the anime has when complete.
    /// </summary>
    [GqlSelection("episodes")] public int? Episodes { get; private set; }

    /// <summary>
    /// The general length of each anime episode.
    /// </summary>
    public TimeSpan? Duration => _duration.HasValue ? new TimeSpan(0, _duration.Value, 0) : null;

    /// <summary>
    /// The amount of chapters the manga has when complete.
    /// </summary>
    [GqlSelection("chapters")] public int? Chapters { get; private set; }

    /// <summary>
    /// The amount of volumes the manga has when complete.
    /// </summary>
    [GqlSelection("volumes")] public int? Volumes { get; private set; }

    /// <summary>
    /// Source type the media was adapted from.
    /// </summary>
    [GqlSelection("source")] [GqlParameter("version", 3)] public MediaSource? Source { get; private set; }

    /// <summary>
    /// When the media's data was last updated.
    /// </summary>
    public DateTime UpdatedAt => DateTimeOffset.FromUnixTimeSeconds(_updatedAt).DateTime;

    /// <summary>
    /// The cover images of the media.
    /// </summary>
    [GqlSelection("coverImage")] public MediaCover Cover { get; private set; }

    /// <summary>
    /// The banner image of the media.
    /// </summary>
    [GqlSelection("bannerImage")] public Uri? BannerImageUrl { get; private set; }

    /// <summary>
    /// The genres of the media.
    /// </summary>
    [GqlSelection("genres")] public string[] Genres { get; private set; }

    /// <summary>
    /// Alternative titles of the media.
    /// </summary>
    [GqlSelection("synonyms")] public string[] Synonyms { get; private set; }

    /// <summary>
    /// A weighted average score of all the user's scores of the media.
    /// </summary>
    [GqlSelection("averageScore")] public int? AverageScore { get; private set; }

    /// <summary>
    /// Mean score of all the user's scores of the media.
    /// </summary>
    [GqlSelection("meanScore")] public int? MeanScore { get; private set; }

    /// <summary>
    /// The number of users with the media on their list.
    /// </summary>
    [GqlSelection("popularity")] public int Popularity { get; private set; }

    /// <summary>
    /// The amount of user's who have favorite the media.
    /// </summary>
    [GqlSelection("favourites")] public int Favorites { get; private set; }

    /// <summary>
    /// If the media is intended only for 18+ adult audiences.
    /// </summary>
    [GqlSelection("isAdult")] public bool IsAdult { get; private set; }

    /// <summary>
    /// If the media is officially licensed or a self-published doujin release.
    /// </summary>
    [GqlSelection("isLicensed")] public bool IsLicensed { get; private set; }

    /// <summary>
    /// The URL for the media page on the AniList website.
    /// </summary>
    [GqlSelection("siteUrl")] public Uri Url { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the media is marked as favorite by the current authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("isFavourite")] public bool IsFavorite { get; private set; }

    /// <summary>
    /// The authenticated user's media list entry for the media.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("mediaListEntry")] public MediaEntrySub? Entry { get; private set; }
}