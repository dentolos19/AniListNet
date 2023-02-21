using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    public async Task<AniPagination<MediaCharacterEdge>> GetCharacterMediaAsync(int characterId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Character", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaCharacterEdge).ToSelections())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", characterId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaCharacterEdge>(
            response["Character"]["media"]["pageInfo"].ToObject<PageInfo>(),
            response["Character"]["media"]["edges"].ToObject<MediaCharacterEdge[]>()
        );
    }

    public async Task<AniPagination<MediaStaffEdge>> GetStaffProductionMediaAsync(int staffId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("staffMedia", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaStaffEdge).ToSelections())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStaffEdge>(
            response["Staff"]["staffMedia"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["staffMedia"]["edges"].ToObject<MediaStaffEdge[]>()
        );
    }

    public async Task<AniPagination<MediaStaffEdge>> GetStaffVoicedMediaAsync(int staffId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characterMedia", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaStaffEdge).ToSelections())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStaffEdge>(
            response["Staff"]["characterMedia"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["characterMedia"]["edges"].ToObject<MediaStaffEdge[]>()
        );
    }

    public async Task<AniPagination<CharacterEdge>> GetStaffVoicedCharactersAsync(int staffId, CharacterSort sort = CharacterSort.Relevance, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(CharacterEdge).ToSelections())
            }, new GqlParameter[]
            {
                new("sort", sort)
            }.Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<CharacterEdge>(
            response["Staff"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    public async Task<AniPagination<MediaStudioEdge>> GetStudioMediaAsync(int studioId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Studio", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaStudioEdge).ToSelections())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", studioId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStudioEdge>(
            response["Studio"]["media"]["pageInfo"].ToObject<PageInfo>(),
            response["Studio"]["media"]["edges"].ToObject<MediaStudioEdge[]>()
        );
    }
}