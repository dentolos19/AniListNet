using AniListNet.Objects;

namespace AniListNet;

public static partial class AniExtensions
{
    public static Task<AniPagination<User>> GetFollowersAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserFollowersAsync(user.Id, pagination);
    }

    public static Task<AniPagination<User>> GetFollowingsAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserFollowingsAsync(user.Id, pagination);
    }

    public static Task<AniPagination<Media>> GetAnimeFavoritesAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserAnimeFavoritesAsync(user.Id, pagination);
    }

    public static Task<AniPagination<Media>> GetMangaFavoritesAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserMangaFavoritesAsync(user.Id, pagination);
    }

    public static Task<AniPagination<Character>> GetCharacterFavoritesAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserCharacterFavoritesAsync(user.Id, pagination);
    }

    public static Task<AniPagination<Staff>> GetStaffFavoritesAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserStaffFavoritesAsync(user.Id, pagination);
    }

    public static Task<AniPagination<Studio>> GetStudioFavoritesAsync
    (
        this User user,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetUserStudioFavoritesAsync(user.Id, pagination);
    }
}