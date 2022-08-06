using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{

    public async Task<AniPagination<MediaCharacterEdge>> GetCharacterMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Character", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaCharacterEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaCharacterEdge>(
            response["Character"]["media"]["pageInfo"].ToObject<PageInfo>(),
            response["Character"]["media"]["edges"].ToObject<MediaCharacterEdge[]>()
        );
    }

    public async Task<AniPagination<MediaStaffEdge>> GetStaffProductionMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("staffMedia", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaStaffEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStaffEdge>(
            response["Staff"]["staffMedia"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["staffMedia"]["edges"].ToObject<MediaStaffEdge[]>()
        );
    }

    public async Task<AniPagination<MediaStaffEdge>> GetStaffVoicedMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characterMedia", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaStaffEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStaffEdge>(
            response["Staff"]["characterMedia"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["characterMedia"]["edges"].ToObject<MediaStaffEdge[]>()
        );
    }

    public async Task<AniPagination<CharacterEdge>> GetStaffVoicedCharactersAsync(int id, CharacterSort sort = CharacterSort.Relevance, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(CharacterEdge).ToSelections())
            }, new GqlParameter[]
            {
                new("sort", sort)
            }.Concat(options.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<CharacterEdge>(
            response["Staff"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    public async Task<AniPagination<MediaStudioEdge>> GetStudioMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Studio", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaStudioEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStudioEdge>(
            response["Studio"]["media"]["pageInfo"].ToObject<PageInfo>(),
            response["Studio"]["media"]["edges"].ToObject<MediaStudioEdge[]>()
        );
    }

}