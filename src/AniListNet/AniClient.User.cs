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
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("followers", GqlParser.ParseToSelections<User>(), new GqlParameter[]
            {
                new("userId", userId)
            })
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<User[]>(response["Page"]["followers"])
        );
    }

    public async Task<AniPagination<User>> GetUserFollowingsAsync(int userId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("following", GqlParser.ParseToSelections<User>(), new GqlParameter[]
            {
                new("userId", userId)
            })
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<User>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<User[]>(response["Page"]["following"])
        );
    }

    public async Task<AniPagination<MediaEntry>> GetUserEntriesAsync(int userId, MediaEntryFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new MediaEntryFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
            new("mediaList", GqlParser.ParseToSelections<MediaEntry>(), new GqlParameter[]
            {
                new("userId", userId)
            }.Concat(filter.ToParameters()))
        }, paginationOptions.ToParameters());
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEntry>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaEntry[]>(response["Page"]["mediaList"])
        );
    }

    public async Task<MediaEntryCollection> GetUserEntryCollectionAsync(int userId, MediaType type, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("MediaListCollection", GqlParser.ParseToSelections<MediaEntryCollection>(), new GqlParameter[]
        {
            new("userId", userId),
            new("type", type),
            new("chunk", paginationOptions.PageIndex),
            new("perChunk", paginationOptions.PageSize)
        });
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaEntryCollection>(response["MediaListCollection"]);
    }

    public async Task<MediaListCollection> GetUserListCollectionAsync(int userId, MediaType type)
    {
        var selections = new GqlSelection("MediaListCollection", GqlParser.ParseToSelections<MediaListCollection>(), new GqlParameter[]
        {
            new("userId", userId),
            new("type", type)
        });
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaListCollection>(response["MediaListCollection"]);
    }

    public async Task<AniPagination<MediaReview>> GetUserMediaReviewsAsync(int userId, MediaReviewFilter? filter = null, AniPaginationOptions? pagination = null)
    {
        filter ??= new MediaReviewFilter();
        pagination ??= new AniPaginationOptions();
        var selections = new GqlSelection("Page")
        {
            Parameters = pagination.ToParameters(),
            Selections = new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("reviews", GqlParser.ParseToSelections<MediaReview>(), filter.ToParameters().Concat(new GqlParameter[]
                {
                    new("userId", userId)
                }))
            }
        };
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaReview>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaReview[]>(response["Page"]["reviews"])
        );
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

    /* below are methods made for private use */

    private async Task<AniPagination<TObject>> GetUserFavoritesAsync<TObject>(int userId, string type, AniPaginationOptions paginationOptions)
    {
        var selections = new GqlSelection("User", new GqlSelection[]
        {
            new("favourites", new GqlSelection[]
            {
                new(type, new GqlSelection[]
                {
                    new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                    new("nodes", GqlParser.ParseToSelections<TObject>())
                }, paginationOptions.ToParameters())
            })
        }, new GqlParameter[]
        {
            new("id", userId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<TObject>(
            GqlParser.ParseFromJson<PageInfo>(response["User"]["favourites"][type]["pageInfo"]),
            GqlParser.ParseFromJson<TObject[]>(response["User"]["favourites"][type]["nodes"])
        );
    }
}