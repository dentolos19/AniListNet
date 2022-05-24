using System.Net.Http.Headers;
using AniListNet.Helpers;
using AniListNet.Objects;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;

namespace AniListNet;

public partial class AniClient
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

    public async Task<bool> TryAuthenticateAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        try
        {
            _ = await GetAuthenticatedUserAsync();
            return true;
        }
        catch
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            return false;
        }
    }

    public async Task<User> GetAuthenticatedUserAsync()
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Viewer", GqlParser.ParseType(typeof(User))));
        var response = await SendRequestAsync(request);
        return response["Viewer"].ToObject<User>();
    }

}