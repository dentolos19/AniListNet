using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    /// <summary>
    /// Gets a collection of supported genres.
    /// </summary>
    public async Task<string[]> GetGenreCollectionAsync()
    {
        var selections = new GqlSelection("GenreCollection");
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<string[]>(response["GenreCollection"]);
    }

    /// <summary>
    /// Gets a collection of supported tags.
    /// </summary>
    public async Task<MediaTag[]> GetTagCollectionAsync()
    {
        var selections = new GqlSelection("MediaTagCollection")
        {
            Selections = GqlParser.ParseToSelections<MediaTag>().ToArray()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaTag[]>(response["MediaTagCollection"]);
    }

    /// <summary>
    /// Gets the media with the given ID.
    /// </summary>
    public async Task<Media> GetMediaAsync(int mediaId)
    {
        var selections = new GqlSelection("Media")
        {
            Parameters = new GqlParameter[] { new("id", mediaId) },
            Selections = GqlParser.ParseToSelections<Media>().ToArray()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<Media>(response["Media"]);
    }

    /// <summary>
    /// Gets the review with the given ID.
    /// </summary>
    public async Task<MediaReview> GetMediaReviewAsync(int reviewId)
    {
        var selections = new GqlSelection("Review")
        {
            Parameters = new GqlParameter[] { new("id", reviewId) },
            Selections = GqlParser.ParseToSelections<MediaReview>().ToArray()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaReview>(response["Review"]);
    }

    /// <summary>
    /// Gets collection of media schedules.
    /// </summary>
    public async Task<AniPagination<MediaSchedule>> GetMediaSchedulesAsync(MediaSchedulesFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new MediaSchedulesFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page")
        {
            Parameters = paginationOptions.ToParameters(),
            Selections = new GqlSelection[] {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("airingSchedules",  GqlParser.ParseToSelections<MediaSchedule>(), filter.ToParameters())
            }
        };
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaSchedule>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaSchedule[]>(response["Page"]["airingSchedules"])
        );
    }

    /// <summary>
    /// Gets collection of trending media.
    /// </summary>
    public async Task<AniPagination<MediaTrend>> GetTrendingMediaAsync(MediaTrendFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new MediaTrendFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page")
        {
            Parameters = paginationOptions.ToParameters(),
            Selections = new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("mediaTrends", typeof(MediaTrend).ToSelections(), filter.ToParameters())
            }
        };
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaTrend>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaTrend[]>(response["Page"]["mediaTrends"])
        );
    }

    /// <summary>
    /// Gets the character with the given ID.
    /// </summary>
    public async Task<Character> GetCharacterAsync(int characterId)
    {
        var selections = new GqlSelection("Character")
        {
            Parameters = new GqlParameter[] { new("id", characterId) },
            Selections = GqlParser.ParseToSelections<Character>()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<Character>(response["Character"]);
    }

    /// <summary>
    /// Gets the staff with the given ID.
    /// </summary>
    public async Task<Staff> GetStaffAsync(int staffId)
    {
        var selections = new GqlSelection("Staff")
        {
            Parameters = new GqlParameter[] { new("id", staffId) },
            Selections = GqlParser.ParseToSelections<Staff>()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<Staff>(response["Staff"]);
    }

    /// <summary>
    /// Gets the studio with the given ID.
    /// </summary>
    public async Task<Studio> GetStudioAsync(int studioId)
    {
        var selections = new GqlSelection("Studio")
        {
            Parameters = new GqlParameter[] { new("id", studioId) },
            Selections = GqlParser.ParseToSelections<Studio>()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<Studio>(response["Studio"]);
    }

    /// <summary>
    /// Gets the user with the given ID.
    /// </summary>
    public async Task<User> GetUserAsync(int userId)
    {
        var selections = new GqlSelection("User")
        {
            Parameters = new GqlParameter[] { new("id", userId) },
            Selections = GqlParser.ParseToSelections<User>()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<User>(response["User"]);
    }
}