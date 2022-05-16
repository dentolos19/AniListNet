using AniListNet.Helpers;
using AniListNet.Objects;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;

namespace AniListNet;

public class AniClient
{

    private readonly GraphQLHttpClient _client;
    private readonly HttpClient _httpClient;

    public event EventHandler<AniRateEventArgs>? RateChanged;

    public AniClient()
    {
        _httpClient = new HttpClient();
        _client = new GraphQLHttpClient(new GraphQLHttpClientOptions { EndPoint = new Uri("https://graphql.anilist.co") }, new NewtonsoftJsonSerializer(), _httpClient);
    }

    private async Task<JObject> SendRequestAsync(string request, GqlType type = GqlType.Query)
    {
        GraphQLResponse<JObject>? response;
        if (type == GqlType.Query)
            response = await _client.SendQueryAsync<JObject>(new GraphQLRequest(request));
        else
            response = await _client.SendMutationAsync<JObject>(new GraphQLRequest(request));
        var headers = response.AsGraphQLHttpResponse().ResponseHeaders;
        headers.TryGetValues("X-RateLimit-Limit", out var rateLimitValues);
        headers.TryGetValues("X-RateLimit-Remaining", out var rateRemainingValues);
        var rateLimitString = rateLimitValues?.FirstOrDefault();
        var rateRemainingString = rateRemainingValues?.FirstOrDefault();
        var rateLimitValidated = int.TryParse(rateLimitString, out var rateLimit);
        var rateRemainingValidated = int.TryParse(rateRemainingString, out var rateRemaining);
        if (rateLimitValidated && rateRemainingValidated)
            RateChanged?.Invoke(this, new AniRateEventArgs(rateLimit, rateRemaining));
        return response.Data;
    }

    public async Task<AniPagination<Media>> SearchMediaAsync(AniFilter filter, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var parameters = new List<GqlParameter> { new("sort", filter.Sort) };
        if (!string.IsNullOrEmpty(filter.Query))
            parameters.Add(new GqlParameter("search", filter.Query));
        if (filter.Type != null)
            parameters.Add(new GqlParameter("type", filter.Type));
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Page", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("media", GqlParser.ParseType(typeof(Media)), parameters.ToArray())
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        });
        var response = await SendRequestAsync(request);
        var page = response["Page"];
        var pageInfo = page["pageInfo"].ToObject<PageInfo>();
        var media = page["media"].ToObject<Media[]>();
        return new AniPagination<Media>(pageInfo, media);
    }

    public async Task<Media> GetMediaAsync(int id)
    {
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Media", GqlParser.ParseType(typeof(Media)), new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Media"].ToObject<Media>();
    }

    public async Task<Media[]> GetMediaRelationsAsync(int id)
    {
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Media", new GqlSelection[]
            {
                new("relations", new GqlSelection[]
                {
                    new("nodes", GqlParser.ParseType(typeof(Media)))
                })
            }, new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Media"]["relations"]["nodes"].ToObject<Media[]>();
    }

    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Media", new GqlSelection[]
            {
                new("characters", new GqlSelection[]
                {
                    new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                    new("edges", GqlParser.ParseType(typeof(CharacterEdge)))
                }, new GqlParameter[]
                {
                    new("page", options.PageIndex),
                    new("perPage", options.PageSize)
                })
            }, new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        var data = response["Media"]["characters"];
        var pageInfo = data["pageInfo"].ToObject<PageInfo>();
        var characters = data["edges"].ToObject<CharacterEdge[]>();
        return new AniPagination<CharacterEdge>(pageInfo, characters);
    }

    public async Task<AniPagination<StaffEdge>> GetMediaStaffAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Media", new GqlSelection[]
            {
                new("staff", new GqlSelection[]
                {
                    new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                    new("edges", GqlParser.ParseType(typeof(StaffEdge)))
                }, new GqlParameter[]
                {
                    new("page", options.PageIndex),
                    new("perPage", options.PageSize)
                })
            }, new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        var data = response["Media"]["staff"];
        var pageInfo = data["pageInfo"].ToObject<PageInfo>();
        var staff = data["edges"].ToObject<StaffEdge[]>();
        return new AniPagination<StaffEdge>(pageInfo, staff);
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Character", GqlParser.ParseType(typeof(Character)), new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Character"].ToObject<Character>();
    }

    public async Task<Staff> GetStaffAsync(int id)
    {
        var request = GqlParser.ParseSelections(GqlType.Query, new GqlSelection[]
        {
            new("Staff", GqlParser.ParseType(typeof(Staff)), new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Staff"].ToObject<Staff>();
    }

}