using System.Net;
using System.Net.Http.Headers;
using System.Text;
using AniListNet.Helpers;
using Newtonsoft.Json.Linq;

namespace AniListNet;

public partial class AniClient
{
    private readonly HttpClient _client = new();
    private readonly Uri _url = new("https://graphql.anilist.co");

    public bool IsAuthenticated { get; private set; }

    public event EventHandler<AniRateEventArgs>? RateChanged;

    public async Task<bool> TryAuthenticateAsync(string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        try
        {
            _ = await GetAuthenticatedUserAsync();
            IsAuthenticated = true;
        }
        catch (AniException aniException)
        {
            if (aniException.StatusCode != HttpStatusCode.Unauthorized)
                throw;
            _client.DefaultRequestHeaders.Authorization = null;
            IsAuthenticated = false;
        }

        return IsAuthenticated;
    }

    private async Task<JToken> PostRequestAsync(GqlSelection selection, bool isMutation = false)
    {
        // Build selection
        var bodyJson = JObject.FromObject(new { query = (isMutation ? "mutation" : string.Empty) + selection });
        var bodyText = bodyJson["query"]!.ToObject<string>();
        var body = new StringContent(bodyJson.ToString(), Encoding.UTF8, "application/json");

        // Send request
        var response = await _client.PostAsync(_url, body);

        // Parse response
        var responseText = await response.Content.ReadAsStringAsync();
        var responseJson = JObject.Parse(responseText);

        if (!response.IsSuccessStatusCode)
            throw new AniException
            (
                responseJson["errors"]!.First!["message"]!.ToString(),
                bodyText!,
                responseText,
                response.StatusCode
            );

        // Check rate limit
        response.Headers.TryGetValues("Retry-After", out var retryAfterValues);
        response.Headers.TryGetValues("X-RateLimit-Limit", out var rateLimitValues);
        response.Headers.TryGetValues("X-RateLimit-Remaining", out var rateRemainingValues);
        response.Headers.TryGetValues("X-RateLimit-Reset", out var rateResetValues);

        var retryAfterString = retryAfterValues?.FirstOrDefault();
        var rateLimitString = rateLimitValues?.FirstOrDefault();
        var rateRemainingString = rateRemainingValues?.FirstOrDefault();
        var rateResetString = rateResetValues?.FirstOrDefault();

        var retryAfterValidated = int.TryParse(retryAfterString, out var retryAfter);
        var rateLimitValidated = int.TryParse(rateLimitString, out var rateLimit);
        var rateRemainingValidated = int.TryParse(rateRemainingString, out var rateRemaining);
        var rateResetValidated = int.TryParse(rateResetString, out var rateReset);

        if (retryAfterValidated && rateLimitValidated && rateRemainingValidated && rateResetValidated)
            RateChanged?.Invoke(this, new AniRateEventArgs(rateLimit, rateRemaining, retryAfter, rateReset));
        else if (rateLimitValidated && rateRemainingValidated)
            RateChanged?.Invoke(this, new AniRateEventArgs(rateLimit, rateRemaining));

        return responseJson["data"]!;
    }

    private async Task<JToken> GetSingleDataAsync(params GqlSelection[] path)
    {
        // Build path to selection
        var selection = path[^1];
        for (var index = path.Length - 2; index >= 0; index--)
        {
            var newSelection = path[index];
            newSelection.Selections ??= new List<GqlSelection>();
            newSelection.Selections.Add(selection);
            selection = newSelection;
        }

        // Send request
        var token = await PostRequestAsync(selection);

        // Get value from path
        token = path.Aggregate(token, (current, item) => current![item.Name]!);

        return token!;
    }
}