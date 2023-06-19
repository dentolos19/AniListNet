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
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("media", GqlParser.ParseToSelections<Media>(), filter.ToParameters().ToArray())
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Media>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<Media[]>(response["Page"]["media"])
        );
    }

    public async Task<AniPagination<Character>> SearchCharacterAsync(SearchCharacterFilter filter, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("characters", GqlParser.ParseToSelections<Character>(), filter.ToParameters().ToArray())
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Character>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<Character[]>(response["Page"]["characters"])
        );
    }

    public async Task<AniPagination<Staff>> SearchStaffAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("staff", GqlParser.ParseToSelections<Staff>(), new GqlParameter[]
            {
                new("search", query)
            })
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Staff>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<Staff[]>(response["Page"]["staff"])
        );
    }

    public async Task<AniPagination<Studio>> SearchStudioAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("studios", GqlParser.ParseToSelections<Studio>(), new GqlParameter[]
            {
                new("search", query)
            })
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<Studio>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<Studio[]>(response["Page"]["studios"])
        );
    }

    public async Task<AniPagination<User>> SearchUserAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("users", GqlParser.ParseToSelections<User>(), new GqlParameter[]
            {
                new("search", query)
            })
        }, options.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<User[]>(response["Page"]["users"])
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