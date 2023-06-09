using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    /// <summary>
    /// Gets tags associated with the given media ID.
    /// </summary>
    public async Task<MediaTag[]> GetMediaTagsAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("tags", typeof(MediaTag).ToSelections())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["tags"].ToObject<MediaTag[]>();
    }

    /// <summary>
    /// Gets relations associated with the given media ID.
    /// </summary>
    public async Task<MediaRelationEdge[]> GetMediaRelationsAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("relations", new GqlSelection[]
            {
                new("edges", typeof(MediaRelationEdge).ToSelections())
            })
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["relations"]["edges"].ToObject<MediaRelationEdge[]>();
    }

    /// <summary>
    /// Gets characters associated with the given media ID.
    /// </summary>
    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(CharacterEdge).ToSelections())
            }, new GqlParameter[]
            {
                new("sort", CharacterSort.Role)
            }.Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<CharacterEdge>(
            response["Media"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    /// <summary>
    /// Gets staff members associated with the given media ID.
    /// </summary>
    public async Task<AniPagination<StaffEdge>> GetMediaStaffAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("staff", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(StaffEdge).ToSelections())
            }, paginationOptions.ToParameters())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<StaffEdge>(
            response["Media"]["staff"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["staff"]["edges"].ToObject<StaffEdge[]>()
        );
    }

    /// <summary>
    /// Gets studios associated with the given media ID.
    /// </summary>
    public async Task<StudioEdge[]> GetMediaStudiosAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("studios", new GqlSelection[]
            {
                new("edges", typeof(StudioEdge).ToSelections())
            })
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["studios"]["edges"].ToObject<StudioEdge[]>();
    }

    /// <summary>
    /// Gets recommendations associated with the given media ID.
    /// </summary>
    public async Task<AniPagination<MediaRecommendationEdge>> GetMediaRecommendationsAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("recommendations", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaRecommendationEdge).ToSelections())
            }, paginationOptions.ToParameters())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaRecommendationEdge>(
            response["Media"]["recommendations"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["recommendations"]["edges"].ToObject<MediaRecommendationEdge[]>()
        );
    }

    /// <summary>
    /// Gets reviews associated with the given media ID.
    /// </summary>
    public async Task<AniPagination<MediaReviewEdge>> GetMediaReviewsAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("reviews", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaReviewEdge).ToSelections())
            }, paginationOptions.ToParameters())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaReviewEdge>(
            response["Media"]["reviews"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["reviews"]["edges"].ToObject<MediaReviewEdge[]>()
        );
    }

    /* below is properties only for the authenticated user */

    public async Task<MediaEntry?> GetMediaEntryAsync(int mediaId)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("mediaListEntry", typeof(MediaEntry).ToSelections())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["mediaListEntry"].ToObject<MediaEntry?>();
    }
}