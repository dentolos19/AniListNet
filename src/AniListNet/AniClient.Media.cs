﻿using AniListNet.Helpers;
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
        var selections = new GqlSelection("Media")
        {
            Parameters = new GqlParameter[] { new("id", mediaId) },
            Selections = new GqlSelection[] { new("tags", GqlParser.ParseToSelections<MediaTag>()) }
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaTag[]>(response["Media"]["tags"]);
    }

    /// <summary>
    /// Gets relations associated with the given media ID.
    /// </summary>
    public async Task<MediaRelationEdge[]> GetMediaRelationsAsync(int mediaId)
    {
        var selections = new GqlSelection("Media")
        {
            Parameters = new GqlParameter[] { new("id", mediaId) },
            Selections = new GqlSelection[]
            {
                new("relations", new GqlSelection[]
                {
                    new("edges", GqlParser.ParseToSelections<MediaRelationEdge>())
                })
            }
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaRelationEdge[]>(response["Media"]["relations"]["edges"]);
    }

    /// <summary>
    /// Gets characters associated with the given media ID.
    /// </summary>
    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int mediaId, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media")
        {
            Parameters = new GqlParameter[] { new("id", mediaId) },
            Selections = new GqlSelection[]
            {
                new("characters")
                {
                    Parameters = new GqlParameter[] { new("sort", CharacterSort.Role) }.Concat(paginationOptions.ToParameters()).ToArray(),
                    Selections = new GqlSelection[]
                    {
                        new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                        new("edges", GqlParser.ParseToSelections<CharacterEdge>())
                    }
                }
            }
        };
        var response = await PostRequestAsync(selections);
        return new AniPagination<CharacterEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Media"]["characters"]["pageInfo"]),
            GqlParser.ParseFromJson<CharacterEdge[]>(response["Media"]["characters"]["edges"])
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
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<StaffEdge>())
            }, paginationOptions.ToParameters())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<StaffEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Media"]["staff"]["pageInfo"]),
            GqlParser.ParseFromJson<StaffEdge[]>(response["Media"]["staff"]["edges"])
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
                new("edges", GqlParser.ParseToSelections<StudioEdge>())
            })
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<StudioEdge[]>(response["Media"]["studios"]["edges"]);
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
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<MediaRecommendationEdge>())
            }, paginationOptions.ToParameters())
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaRecommendationEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Media"]["recommendations"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaRecommendationEdge[]>(response["Media"]["recommendations"]["edges"])
        );
    }

    /// <summary>
    /// Gets reviews associated with the given media ID.
    /// </summary>
    public async Task<AniPagination<MediaReview>> GetMediaReviewsAsync(int mediaId, MediaReviewFilter? filter = null, AniPaginationOptions? pagination = null)
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
                    new("mediaId", mediaId)
                }))
            }
        };
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaReview>(
            GqlParser.ParseFromJson<PageInfo>(response["Page"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaReview[]>(response["Page"]["reviews"])
        );
    }

    /* below is properties only for the authenticated user */

    public async Task<MediaEntry?> GetMediaEntryAsync(int mediaId)
    {
        var selections = new GqlSelection("Media")
        {
            Parameters = new GqlParameter[] { new("id", mediaId) },
            Selections = new GqlSelection[] { new("mediaListEntry", GqlParser.ParseToSelections<MediaEntry>()) }
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<MediaEntry?>(response["Media"]["mediaListEntry"]);
    }
}