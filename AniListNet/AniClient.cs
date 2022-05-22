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
        if (filter.Season != null)
            parameters.AddRange(new GqlParameter[]
            {
                new("season", filter.Season),
                new("seasonYear", filter.SeasonYear)
            });
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("media", GqlParser.ParseType(typeof(Media)), parameters.ToArray())
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Media>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["media"].ToObject<Media[]>()
        );
    }

    public async Task<AniPagination<Character>> SearchCharacterAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
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
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Character>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["characters"].ToObject<Character[]>()
        );
    }

    public async Task<AniPagination<Staff>> SearchStaffAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
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
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Staff>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["staff"].ToObject<Staff[]>()
        );
    }

    public async Task<AniPagination<Studio>> SearchStudioAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
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
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<Studio>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["studios"].ToObject<Studio[]>()
        );
    }

    public async Task<AniPagination<User>> SearchUserAsync(string query, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
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
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<User>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["users"].ToObject<User[]>()
        );
    }

    #endregion

    #region Get Functions

    public async Task<string[]> GetGenreCollectionAsync()
    {
        var request = GqlParser.ParseSelection(new GqlSelection("GenreCollection"));
        var response = await SendRequestAsync(request);
        return response["GenreCollection"].ToObject<string[]>();
    }

    public async Task<MediaTag[]> GetTagCollectionAsync()
    {
        var request = GqlParser.ParseSelection(new GqlSelection("MediaTagCollection", GqlParser.ParseType(typeof(MediaTag))));
        var response = await SendRequestAsync(request);
        return response["MediaTagCollection"].ToObject<MediaTag[]>();
    }

    public async Task<Media> GetMediaAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Media", GqlParser.ParseType(typeof(Media)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Media"].ToObject<Media>();
    }

    public async Task<AniPagination<MediaSchedule>> GetMediaSchedulesAsync(AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Page", new GqlSelection[]
        {
            new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
            new("airingSchedules", GqlParser.ParseType(typeof(MediaSchedule)))
        }, new GqlParameter[]
        {
            new("page", options.PageIndex),
            new("perPage", options.PageSize)
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<MediaSchedule>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["airingSchedules"].ToObject<MediaSchedule[]>()
        );
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Character", GqlParser.ParseType(typeof(Character)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Character"].ToObject<Character>();
    }

    public async Task<Staff> GetStaffAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Staff", GqlParser.ParseType(typeof(Staff)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Staff"].ToObject<Staff>();
    }

    public async Task<Studio> GetStudioAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Studio", GqlParser.ParseType(typeof(Studio)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Studio"].ToObject<Studio>();
    }

    public async Task<User> GetUserAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("User", GqlParser.ParseType(typeof(User)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["User"].ToObject<User>();
    }

    #endregion

    #region Media-Specific Get Functions

    public async Task<MediaEdge[]> GetMediaRelationsAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
        {
            new("relations", new GqlSelection[]
            {
                new("edges", GqlParser.ParseType(typeof(MediaEdge)))
            })
        }, new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Media"]["relations"]["edges"].ToObject<MediaEdge[]>();
    }

    public async Task<AniPagination<CharacterEdge>> GetMediaCharactersAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
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
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<CharacterEdge>(
            response["Media"]["characters"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["characters"]["edges"].ToObject<CharacterEdge[]>()
        );
    }

    public async Task<AniPagination<StaffEdge>> GetMediaStaffAsync(int id, AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
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
        }));
        var response = await SendRequestAsync(request);
        return new AniPagination<StaffEdge>(
            response["Media"]["staff"]["pageInfo"].ToObject<PageInfo>(),
            response["Media"]["staff"]["edges"].ToObject<StaffEdge[]>()
        );
    }

    public async Task<StudioEdge[]> GetMediaStudiosAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Media", new GqlSelection[]
        {
            new("studios", new GqlSelection[]
            {
                new("edges", GqlParser.ParseType(typeof(StudioEdge)))
            })
        }, new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await SendRequestAsync(request);
        return response["Media"]["studios"]["edges"].ToObject<StudioEdge[]>();
    }

    #endregion

}