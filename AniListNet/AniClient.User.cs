using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public async Task<AniPagination<User>> GetUserFollowersAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("followers", typeof(User).ToSelections(), new GqlParameter[]
            {
                new("userId", id)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["followers"].ToObject<User[]>()
        );
    }

    public async Task<AniPagination<User>> GetUserFollowingsAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("following", typeof(User).ToSelections(), new GqlParameter[]
            {
                new("userId", id)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["following"].ToObject<User[]>()
        );
    }

    public async Task<AniPagination<MediaEntry>> GetUserEntriesAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("mediaList", typeof(MediaEntry).ToSelections(), new GqlParameter[]
            {
                new("userId", id)
            })
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEntry>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["mediaList"].ToObject<MediaEntry[]>()
        );
    }

    public async Task<MediaEntryCollection> GetUserEntryCollectionAsync(int id, MediaType type, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("MediaListCollection", typeof(MediaEntryCollection).ToSelections(), new GqlParameter[]
        {
            new("userId", id),
            new("type", type),
            new("chunk", options.PageIndex),
            new("perChunk", options.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return response["MediaListCollection"].ToObject<MediaEntryCollection>();
    }

    public Task<AniPagination<Media>> GetUserAnimeFavoritesAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Media>(id, "anime", options);
    }

    public Task<AniPagination<Media>> GetUserMangaFavoritesAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Media>(id, "manga", options);
    }

    public Task<AniPagination<Character>> GetUserCharacterFavoritesAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Character>(id, "characters", options);
    }

    public Task<AniPagination<Staff>> GetUserStaffFavoritesAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Staff>(id, "staff", options);
    }

    public Task<AniPagination<Studio>> GetUserStudioFavoritesAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Studio>(id, "studios", options);
    }

    /* below is methods that is privately used */

    private async Task<AniPagination<T>> GetUserFavoritesAsync<T>(int id, string type, AniPaginationOptions options)
    {
        var selections = new GqlSelection("User", new GqlSelection[]
        {
            new("favourites", new GqlSelection[]
            {
                new(type, new GqlSelection[]
                {
                    new("pageInfo", typeof(PageInfo).ToSelections()),
                    new("nodes", typeof(T).ToSelections())
                }, new GqlParameter[]
                {
                    new("page", options.PageIndex),
                    new("perPage", options.PageSize)
                })
            })
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<T>(
            response["User"]["favourites"][type]["pageInfo"].ToObject<PageInfo>(),
            response["User"]["favourites"][type]["nodes"].ToObject<T[]>()
        );
    }

}