using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{

    public async Task<AniPagination<Media>> SearchMediaAsync(SearchMediaFilter filter, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("media", typeof(Media).ToSelections(), filter.ToParameters().ToArray())
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Media>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["media"].ToObject<Media[]>()
        );
    }

    public async Task<AniPagination<Character>> SearchCharacterAsync(SearchCharacterFilter filter, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("characters", typeof(Character).ToSelections(), filter.ToParameters().ToArray())
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Character>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["characters"].ToObject<Character[]>()
        );
    }

    public async Task<AniPagination<Staff>> SearchStaffAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("staff", typeof(Staff).ToSelections(), new GqlParameter[]
            {
                new("search", query)
            })
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Staff>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["staff"].ToObject<Staff[]>()
        );
    }

    public async Task<AniPagination<Studio>> SearchStudioAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("studios", typeof(Studio).ToSelections(), new GqlParameter[]
            {
                new("search", query)
            })
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Studio>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["studios"].ToObject<Studio[]>()
        );
    }

    public async Task<AniPagination<User>> SearchUserAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("users", typeof(User).ToSelections(), new GqlParameter[]
            {
                new("search", query)
            })
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["users"].ToObject<User[]>()
        );
    }

    /* below are methods that are the simplified versions of the above */

    public Task<AniPagination<Media>> SearchMediaAsync(string query, AniPaginationOptions? options = null)
    {
        return SearchMediaAsync(new SearchMediaFilter { Query = query }, options);
    }

    public Task<AniPagination<Character>> SearchCharacterAsync(string query, AniPaginationOptions? options = null)
    {
        return SearchCharacterAsync(new SearchCharacterFilter { Query = query }, options);
    }

}