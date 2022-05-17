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

    private async Task<JObject> SendRequestAsync(string request)
    {
        var response = await _client.SendQueryAsync<JObject>(new GraphQLRequest(request));
        var responseHeaders = response.AsGraphQLHttpResponse().ResponseHeaders;
        responseHeaders.TryGetValues("X-RateLimit-Limit", out var rateLimitValues);
        responseHeaders.TryGetValues("X-RateLimit-Remaining", out var rateRemainingValues);
        var rateLimitString = rateLimitValues?.FirstOrDefault();
        var rateRemainingString = rateRemainingValues?.FirstOrDefault();
        var rateLimitValidated = int.TryParse(rateLimitString, out var rateLimit);
        var rateRemainingValidated = int.TryParse(rateRemainingString, out var rateRemaining);
        if (rateLimitValidated && rateRemainingValidated)
            RateChanged?.Invoke(this, new AniRateEventArgs(rateLimit, rateRemaining));
        return response.Data;
    }

    #region Search Functions

    public Task<AniPagination<Media>> SearchMediaAsync(string query, AniPaginationOptions? options = null)
    {
        return SearchMediaAsync(new AniFilter { Query = query }, options);
    }

    public async Task<AniPagination<Media>> SearchMediaAsync(AniFilter filter, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var parameters = new List<GqlParameter> { new("sort", filter.Sort) };
        if (!string.IsNullOrEmpty(filter.Query))
            parameters.Add(new GqlParameter("search", filter.Query));
        if (filter.Type != null)
            parameters.Add(new GqlParameter("type", filter.Type));
        var request = GqlParser.ParseSelections(new GqlSelection[]
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

    public async Task<AniPagination<Character>> SearchCharacterAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Page", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("characters", GqlParser.ParseType(typeof(Character)), new GqlParameter[]
                {
                    new("search", query)
                })
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        });
        var response = await SendRequestAsync(request);
        var page = response["Page"];
        var pageInfo = page["pageInfo"].ToObject<PageInfo>();
        var characters = page["characters"].ToObject<Character[]>();
        return new AniPagination<Character>(pageInfo, characters);
    }

    public async Task<AniPagination<Staff>> SearchStaffAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Page", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("staff", GqlParser.ParseType(typeof(Staff)), new GqlParameter[]
                {
                    new("search", query)
                })
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        });
        var response = await SendRequestAsync(request);
        var page = response["Page"];
        var pageInfo = page["pageInfo"].ToObject<PageInfo>();
        var staff = page["staff"].ToObject<Staff[]>();
        return new AniPagination<Staff>(pageInfo, staff);
    }

    public async Task<AniPagination<Studio>> SearchStudioAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Page", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("studios", GqlParser.ParseType(typeof(Studio)), new GqlParameter[]
                {
                    new("search", query)
                })
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        });
        var response = await SendRequestAsync(request);
        var page = response["Page"];
        var pageInfo = page["pageInfo"].ToObject<PageInfo>();
        var studios = page["studios"].ToObject<Studio[]>();
        return new AniPagination<Studio>(pageInfo, studios);
    }

    public async Task<AniPagination<User>> SearchUserAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Page", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("users", GqlParser.ParseType(typeof(User)), new GqlParameter[]
                {
                    new("search", query)
                })
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        });
        var response = await SendRequestAsync(request);
        var page = response["Page"];
        var pageInfo = page["pageInfo"].ToObject<PageInfo>();
        var users = page["users"].ToObject<User[]>();
        return new AniPagination<User>(pageInfo, users);
    }

    #endregion

    #region Get Functions

    public async Task<string[]> GetGenreCollectionAsync()
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("GenreCollection")
        });
        var response = await SendRequestAsync(request);
        return response["GenreCollection"].ToObject<string[]>();
    }

    public async Task<MediaTag[]> GetTagCollectionAsync()
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("MediaTagCollection", GqlParser.ParseType(typeof(MediaTag)))
        });
        var response = await SendRequestAsync(request);
        return response["MediaTagCollection"].ToObject<MediaTag[]>();
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
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
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Staff", GqlParser.ParseType(typeof(Staff)), new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Staff"].ToObject<Staff>();
    }

    public async Task<User> GetUserAsync(int id)
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("User", GqlParser.ParseType(typeof(User)), new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["User"].ToObject<User>();
    }

    #endregion

    #region Media-Specific Get Functions

    public async Task<Media> GetMediaAsync(int id)
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Media", GqlParser.ParseType(typeof(Media)), new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Media"].ToObject<Media>();
    }

    public async Task<MediaEdge[]> GetMediaRelationsAsync(int id)
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Media", new GqlSelection[]
            {
                new("relations", new GqlSelection[]
                {
                    new("edges", GqlParser.ParseType(typeof(MediaEdge)))
                })
            }, new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Media"]["relations"]["edges"].ToObject<MediaEdge[]>();
    }

    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelections(new GqlSelection[]
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
        var request = GqlParser.ParseSelections(new GqlSelection[]
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

    public async Task<StudioEdge[]> GetMediaStudiosAsync(int id)
    {
        var request = GqlParser.ParseSelections(new GqlSelection[]
        {
            new("Media", new GqlSelection[]
            {
                new("studios", new GqlSelection[]
                {
                    new("edges", GqlParser.ParseType(typeof(StudioEdge)))
                })
            }, new GqlParameter[]
            {
                new("id", id)
            })
        });
        var response = await SendRequestAsync(request);
        return response["Media"]["studios"]["edges"].ToObject<StudioEdge[]>();
    }

    #endregion

}