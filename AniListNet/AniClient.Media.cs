using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public async Task<MediaTag[]> GetMediaTagsAsync(int id)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("tags", typeof(MediaTag).ToSelections())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["tags"].ToObject<MediaTag[]>();
    }

    public async Task<MediaEdge[]> GetMediaRelationsAsync(int id)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("relations", new GqlSelection[]
            {
                new("edges", typeof(MediaEdge).ToSelections())
            })
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["relations"]["edges"].ToObject<MediaEdge[]>();
    }

    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(CharacterEdge).ToSelections())
            }, new GqlParameter[]
            {
                new("sort", "$ROLE") // TODO: use CharacterRole
            }.Concat(options.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<CharacterEdge>(
            response["Media"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    public async Task<AniPagination<StaffEdge>> GetMediaStaffAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("staff", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(StaffEdge).ToSelections())
            }, options.ToParameters())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<StaffEdge>(
            response["Media"]["staff"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["staff"]["edges"].ToObject<StaffEdge[]>()
        );
    }

    public async Task<StudioEdge[]> GetMediaStudiosAsync(int id)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("studios", new GqlSelection[]
            {
                new("edges", typeof(StudioEdge).ToSelections())
            })
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["studios"]["edges"].ToObject<StudioEdge[]>();
    }

    /* below is properties specific for the authenticated user */

    public async Task<MediaEntry?> GetMediaEntryAsync(int id)
    {
        var selections = new GqlSelection("Media", new GqlSelection[]
        {
            new("mediaListEntry", typeof(MediaEntry).ToSelections())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return response["Media"]["mediaListEntry"].ToObject<MediaEntry?>();
    }

}