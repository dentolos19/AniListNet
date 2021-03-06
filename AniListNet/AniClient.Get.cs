using AniListNet.Helpers;
using AniListNet.Objects;

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

    public async Task<Media> GetMediaAsync(int id)
    {
        var selections = new GqlSelection("Media", typeof(Media).ToSelections(), new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"].ToObject<Media>();
    }

    public async Task<AniPagination<MediaSchedule>> GetMediaSchedulesAsync(AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("airingSchedules", typeof(MediaSchedule).ToSelections(), new GqlParameter[]
            {
                new("notYetAired", true)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaSchedule>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["airingSchedules"].ToObject<MediaSchedule[]>()
        );
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var selections = new GqlSelection("Character", typeof(Character).ToSelections(), new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Character"].ToObject<Character>();
    }

    public async Task<Staff> GetStaffAsync(int id)
    {
        var selections = new GqlSelection("Staff", typeof(Staff).ToSelections(), new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Staff"].ToObject<Staff>();
    }

    public async Task<Studio> GetStudioAsync(int id)
    {
        var selections = new GqlSelection("Studio", typeof(Studio).ToSelections(), new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Studio"].ToObject<Studio>();
    }

    public async Task<User> GetUserAsync(int id)
    {
        var selections = new GqlSelection("User", typeof(User).ToSelections(), new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["User"].ToObject<User>();
    }

}