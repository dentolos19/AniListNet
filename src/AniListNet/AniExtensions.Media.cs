using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public static partial class AniExtensions
{
    public static Task<MediaTag[]> GetTagsAsync
    (
        this Media media,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaTagsAsync(media.Id);
    }

    public static Task<MediaRelationEdge[]> GetRelationsAsync
    (
        this Media media,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaRelationsAsync(media.Id);
    }

    public static Task<AniPagination<CharacterEdge>> GetCharactersAsync
    (
        this Media media,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaCharactersAsync(media.Id, pagination);
    }

    public static Task<AniPagination<StaffEdge>> GetStaffAsync
    (
        this Media media,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaStaffAsync(media.Id, pagination);
    }

    public static Task<StudioEdge[]> GetStudiosAsync
    (
        this Media media,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaStudiosAsync(media.Id);
    }

    public static Task<AniPagination<MediaRecommendationEdge>> GetRecommendationsAsync
    (
        this Media media,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaRecommendationsAsync(media.Id, pagination);
    }

    public static Task<AniPagination<MediaReview>> GetReviewsAsync
    (
        this Media media,
        MediaReviewFilter? filter = null,
        AniPaginationOptions? pagination = null,
        AniClient? client = null
    )
    {
        client ??= new AniClient();
        return client.GetMediaReviewsAsync(media.Id, filter, pagination);
    }
}