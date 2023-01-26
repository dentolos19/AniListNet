using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{

    public async Task<AniPagination<User>> GetUserFollowersAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("followers", typeof(User).ToSelections(), new GqlParameter[]
            {
                new("userId", userId)
            })
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["followers"].ToObject<User[]>()
        );
    }

    public async Task<AniPagination<User>> GetUserFollowingsAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("following", typeof(User).ToSelections(), new GqlParameter[]
            {
                new("userId", userId)
            })
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["following"].ToObject<User[]>()
        );
    }

    public async Task<AniPagination<MediaEntry>> GetUserEntriesAsync(int userId, MediaEntryFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new MediaEntryFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", typeof(PageInfo).ToSelections()),
            new("mediaList", typeof(MediaEntry).ToSelections(), new GqlParameter[]
            {
                new("userId", userId)
            }.Concat(filter.ToParameters()))
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEntry>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["mediaList"].ToObject<MediaEntry[]>()
        );
    }

    public async Task<MediaEntryCollection> GetUserEntryCollectionAsync(int userId, MediaType type, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("MediaListCollection", typeof(MediaEntryCollection).ToSelections(), new GqlParameter[]
        {
            new("userId", userId),
            new("type", type),
            new("chunk", paginationOptions.PageIndex),
            new("perChunk", paginationOptions.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return response["MediaListCollection"].ToObject<MediaEntryCollection>();
    }

    public async Task<MediaListCollection> GetUserListCollectionAsync(int userId, MediaType type)
    {
        var selections = new GqlSelection("MediaListCollection", typeof(MediaListCollection).ToSelections(), new GqlParameter[]
        {
            new("userId", userId),
            new("type", type)
        });
        var response = await PostRequestAsync(selections);
        return response["MediaListCollection"].ToObject<MediaListCollection>();
    }

    public Task<AniPagination<Media>> GetUserAnimeFavoritesAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Media>(userId, "anime", paginationOptions);
    }

    public Task<AniPagination<Media>> GetUserMangaFavoritesAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Media>(userId, "manga", paginationOptions);
    }

    public Task<AniPagination<Character>> GetUserCharacterFavoritesAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Character>(userId, "characters", paginationOptions);
    }

    public Task<AniPagination<Staff>> GetUserStaffFavoritesAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Staff>(userId, "staff", paginationOptions);
    }

    public Task<AniPagination<Studio>> GetUserStudioFavoritesAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        return GetUserFavoritesAsync<Studio>(userId, "studios", paginationOptions);
    }

    /* below is methods that is privately used */

    private async Task<AniPagination<T>> GetUserFavoritesAsync<T>(int userId, string type, AniPaginationOptions paginationOptions)
    {
        var selections = new GqlSelection("User", new GqlSelection[]
        {
            new("favourites", new GqlSelection[]
            {
                new(type, new GqlSelection[]
                {
                    new("pageInfo", typeof(PageInfo).ToSelections()),
                    new("nodes", typeof(T).ToSelections())
                }, paginationOptions.ToParameters())
            })
        }, new GqlParameter[]
        {
            new("id", userId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<T>(
            response["User"]["favourites"][type]["pageInfo"].ToObject<PageInfo>(),
            response["User"]["favourites"][type]["nodes"].ToObject<T[]>()
        );
    }

}