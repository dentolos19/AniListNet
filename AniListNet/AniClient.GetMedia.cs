using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{

    public async Task<AniPagination<MediaEdge>> GetCharacterMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Character", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()).ToList())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEdge>(
            response["Character"]["media"]["pageInfo"].ToObject<PageInfo>(),
            response["Character"]["media"]["edges"].ToObject<MediaEdge[]>()
        );
    }

    public async Task<AniPagination<MediaEdge>> GetStaffProductionMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("staffMedia", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()).ToList())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEdge>(
            response["Staff"]["staffMedia"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["staffMedia"]["edges"].ToObject<MediaEdge[]>()
        );
    }

    public async Task<AniPagination<MediaEdge>> GetStaffVoicedMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characterMedia", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()).ToList())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEdge>(
            response["Staff"]["characterMedia"]["pageInfo"].ToObject<PageInfo>(),
            response["Staff"]["characterMedia"]["edges"].ToObject<MediaEdge[]>()
        );
    }

    public async Task<AniPagination<CharacterEdge>> GetStaffVoicedCharactersAsync(int id, AniPaginationOptions? options = null)
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
                new("sort", "$ROLE")
            }.Concat(options.ToParameters()).ToList())
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

    public async Task<AniPagination<MediaEdge>> GetStudioMediaAsync(int id, GetMediaFilter? filter = null, AniPaginationOptions? options = null)
    {
        filter ??= new GetMediaFilter();
        options ??= new AniPaginationOptions();
        var selections = new GqlSelection("Studio", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", typeof(PageInfo).ToSelections()),
                new("edges", typeof(MediaEdge).ToSelections())
            }, filter.ToParameters().Concat(options.ToParameters()).ToList())
        }, new GqlParameter[]
        {
            new("id", id)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaEdge>(
            response["Studio"]["media"]["pageInfo"].ToObject<PageInfo>(),
            response["Studio"]["media"]["edges"].ToObject<MediaEdge[]>()
        );
    }

}