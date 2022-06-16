using AniListNet.Helpers;
using AniListNet.Models;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public Task<AniPagination<Media>> SearchMediaAsync(string query, AniPaginationOptions? options = null)
    {
        return SearchMediaAsync(new SearchMediaFilter { Query = query }, options);
    }

    public async Task<AniPagination<Media>> SearchMediaAsync(SearchMediaFilter filter, AniPaginationOptions? options = null)
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
        if (filter.IsAdult != null)
            parameters.Add(new GqlParameter("isAdult", filter.IsAdult));
        if (filter.OnList != null)
            parameters.Add(new GqlParameter("onList", filter.OnList));
        if (!string.IsNullOrEmpty(filter.Query))
            parameters.Add(new GqlParameter("search", filter.Query));
        if (filter.Format is { Count: > 0 })
        {
            var (includedItems, excludedItems) = filter.Format.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("format_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("format_not_in", excludedItems));
        }
        if (filter.Status is { Count: > 0 })
        {
            var (includedItems, excludedItems) = filter.Status.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("status_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("status_not_in", excludedItems));
        }
        if (filter.Genres is { Count: > 0 })
        {
            var (includedItems, excludedItems) = filter.Genres.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("genre_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("genre_not_in", excludedItems));
        }
        if (filter.Tags is { Count: > 0 })
        {
            var (includedItems, excludedItems) = filter.Tags.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("tag_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("tag_not_in", excludedItems));
        }
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("media", typeof(Media).ToSelections(), parameters.ToArray())
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<Media>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["media"].ToObject<Media[]>()
        );
    }

    public async Task<AniPagination<Character>> SearchCharacterAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("characters", typeof(Character).ToSelections(), new GqlParameter[]
            {
                new("search", query)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
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
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
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
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
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
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["users"].ToObject<User[]>()
        );
    }

}