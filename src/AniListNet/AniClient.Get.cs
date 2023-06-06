using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    public async Task<string[]> GetGenreCollectionAsync()
    {
        var response = await PostRequestAsync(new GqlSelection("GenreCollection"));
        return response["GenreCollection"].ToObject<string[]>();
    }

    public async Task<MediaTag[]> GetTagCollectionAsync()
    {
        var response = await PostRequestAsync(new GqlSelection("MediaTagCollection", typeof(MediaTag).ToSelections()));
        return response["MediaTagCollection"].ToObject<MediaTag[]>();
    }

    public async Task<Media> GetMediaAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", typeof(Media).ToSelections(), new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"].ToObject<Media>();
    }

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

    public async Task<Character> GetCharacterAsync(int characterId)
    {
        var selections = new GqlSelection("Character", typeof(Character).ToSelections(), new GqlParameter[]
        {
            new("id", characterId)
        });
        var response = await PostRequestAsync(selections);
        return response["Character"].ToObject<Character>();
    }

    public async Task<Staff> GetStaffAsync(int staffId)
    {
        var selections = new GqlSelection("Staff", typeof(Staff).ToSelections(), new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return response["Staff"].ToObject<Staff>();
    }

    public async Task<Studio> GetStudioAsync(int studioId)
    {
        var selections = new GqlSelection("Studio", typeof(Studio).ToSelections(), new GqlParameter[]
        {
            new("id", studioId)
        });
        var response = await PostRequestAsync(selections);
        return response["Studio"].ToObject<Studio>();
    }

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