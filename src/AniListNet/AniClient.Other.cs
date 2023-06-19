using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    /// <summary>
    /// Gets the media that the character was part of.
    /// </summary>
    public async Task<AniPagination<MediaCharacterEdge>> GetCharacterMediaAsync(int characterId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Character", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<MediaCharacterEdge>())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", characterId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaCharacterEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Character"]["media"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaCharacterEdge[]>(response["Character"]["media"]["edges"])
        );
    }

    /// <summary>
    /// Gets the media that the staff was involved in.
    /// </summary>
    public async Task<AniPagination<MediaStaffEdge>> GetStaffProductionMediaAsync(int staffId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("staffMedia", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<MediaStaffEdge>())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStaffEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Staff"]["staffMedia"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaStaffEdge[]>(response["Staff"]["staffMedia"]["edges"])
        );
    }

    /// <summary>
    /// Gets the media that the staff voiced in.
    /// </summary>
    public async Task<AniPagination<MediaStaffEdge>> GetStaffVoicedMediaAsync(int staffId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characterMedia", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<MediaStaffEdge>())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", staffId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStaffEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Staff"]["characterMedia"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaStaffEdge[]>(response["Staff"]["characterMedia"]["edges"])
        );
    }

    /// <summary>
    /// Gets the characters that the staff voiced for.
    /// </summary>
    public async Task<AniPagination<CharacterEdge>> GetStaffVoicedCharactersAsync(int staffId, CharacterSort sort = CharacterSort.Relevance, AniPaginationOptions? paginationOptions = null)
    {
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Staff", new GqlSelection[]
        {
            new("characters", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<CharacterEdge>())
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
            GqlParser.ParseFromJson<PageInfo>(response["Staff"]["characters"]["pageInfo"]),
            GqlParser.ParseFromJson<CharacterEdge[]>(response["Staff"]["characters"]["edges"])
        );
    }

    /// <summary>
    /// Gets the media that the studio produced.
    /// </summary>
    public async Task<AniPagination<MediaStudioEdge>> GetStudioMediaAsync(int studioId, GetMediaFilter? filter = null, AniPaginationOptions? paginationOptions = null)
    {
        filter ??= new GetMediaFilter();
        paginationOptions ??= new AniPaginationOptions();
        var selections = new GqlSelection("Studio", new GqlSelection[]
        {
            new("media", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseToSelections<PageInfo>()),
                new("edges", GqlParser.ParseToSelections<MediaStudioEdge>())
            }, filter.ToParameters().Concat(paginationOptions.ToParameters()))
        }, new GqlParameter[]
        {
            new("id", studioId)
        });
        var response = await PostRequestAsync(selections);
        return new AniPagination<MediaStudioEdge>(
            GqlParser.ParseFromJson<PageInfo>(response["Studio"]["media"]["pageInfo"]),
            GqlParser.ParseFromJson<MediaStudioEdge[]>(response["Studio"]["media"]["edges"])
        );
    }
}