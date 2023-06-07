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
        var response = await PostRequestAsync(new GqlSelection("GenreCollection"));
        return response["GenreCollection"].ToObject<string[]>();
    }

    /// <summary>
    /// Gets a collection of supported tags.
    /// </summary>
    public async Task<MediaTag[]> GetTagCollectionAsync()
    {
        var response = await PostRequestAsync(new GqlSelection("MediaTagCollection", typeof(MediaTag).ToSelections()));
        return response["MediaTagCollection"].ToObject<MediaTag[]>();
    }

    /// <summary>
    /// Gets the media with the given ID.
    /// </summary>
    public async Task<Media> GetMediaAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", typeof(Media).ToSelections(), new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"].ToObject<Media>();
    }

    /// <summary>
    /// Gets collection of media schedules.
    /// </summary>
    public async Task<AniPagination<MediaSchedule>> GetMediaSchedulesAsync(MediaSchedulesFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new MediaSchedulesFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("airingSchedules", typeof(MediaSchedule).ToSelections(), filter.ToParameters())
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaSchedule>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["airingSchedules"].ToObject<MediaSchedule[]>()
        );
    }

    /// <summary>
    /// Gets the character with the given ID.
    /// </summary>
    public async Task<Character> GetCharacterAsync(int characterId)
    {
        var selections = new GqlSelection("Character", typeof(Character).ToSelections(), new GqlParameter[]
        {
            new("id", characterId)
        });
        var response = await PostRequestAsync(selections);
        return response["Character"].ToObject<Character>();
    }

    /// <summary>
    /// Gets the staff with the given ID.
    /// </summary>
    public async Task<Staff> GetStaffAsync(int staffId)
    {
        var selections = new GqlSelection("Staff", typeof(Staff).ToSelections(), new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return response["Staff"].ToObject<Staff>();
    }

    /// <summary>
    /// Gets the studio with the given ID.
    /// </summary>
    public async Task<Studio> GetStudioAsync(int studioId)
    {
        var selections = new GqlSelection("Studio", typeof(Studio).ToSelections(), new GqlParameter[]
        {
            new("id", studioId)
        });
        var response = await PostRequestAsync(selections);
        return response["Studio"].ToObject<Studio>();
    }

    /// <summary>
    /// Gets the user with the given ID.
    /// </summary>
    public async Task<User> GetUserAsync(int userId)
    {
        var selections = new GqlSelection("User", typeof(User).ToSelections(), new GqlParameter[]
        {
            new("id", userId)
        });
        var response = await PostRequestAsync(selections);
        return response["User"].ToObject<User>();
    }

}