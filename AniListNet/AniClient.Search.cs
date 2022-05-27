using AniListNet.Helpers;
using AniListNet.Models;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public Task<AniPagination<Media>> SearchMediaAsync(string query, AniPaginationOptions? options = null)
    {
        return SearchMediaAsync(new MediaFilter { Query = query }, options);
    }

    public async Task<AniPagination<Media>> SearchMediaAsync(MediaFilter filter, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var parameters = new List<GqlParameter> { new("sort", filter.Sort) };
        if (filter.Season != null)
            parameters.AddRange(new GqlParameter[]
            {
                new("season", filter.Season),
                new("seasonYear", filter.SeasonYear)
            });
        if (filter.Type != null)
            parameters.Add(new GqlParameter("type", filter.Type));
        if (!string.IsNullOrEmpty(filter.Query))
            parameters.Add(new GqlParameter("search", filter.Query));
        if (filter.Genres is { Length: > 0 })
            parameters.Add(new GqlParameter("genre_in", filter.Genres));
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("media", GqlParser.ParseType(typeof(Media)), parameters.ToArray())
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Media>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["media"].ToObject<Media[]>()
        );
    }

    public async Task<AniPagination<Character>> SearchCharacterAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("characters", GqlParser.ParseType(typeof(Character)), new GqlParameter[]
            {
                new("search", query)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Character>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["characters"].ToObject<Character[]>()
        );
    }

    public async Task<AniPagination<Staff>> SearchStaffAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("staff", GqlParser.ParseType(typeof(Staff)), new GqlParameter[]
            {
                new("search", query)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Staff>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["staff"].ToObject<Staff[]>()
        );
    }

    public async Task<AniPagination<Studio>> SearchStudioAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("studios", GqlParser.ParseType(typeof(Studio)), new GqlParameter[]
            {
                new("search", query)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Studio>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["studios"].ToObject<Studio[]>()
        );
    }

    public async Task<AniPagination<User>> SearchUserAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("users", GqlParser.ParseType(typeof(User)), new GqlParameter[]
            {
                new("search", query)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["users"].ToObject<User[]>()
        );
    }

}