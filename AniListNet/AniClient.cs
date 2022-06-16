using System.Text;
using AniListNet.Helpers;
using Newtonsoft.Json.Linq;

namespace AniListNet;

public partial class AniClient
{

    private readonly Uri _url = new("https://graphql.anilist.co");
    private readonly HttpClient _client = new();

    public event EventHandler<AniRateEventArgs>? RateChanged;

    private async Task<JToken> PostRequestAsync(GqlSelection selection, bool isMutation = false)
    {
        var body = JObject.FromObject(new { query = (isMutation ? "mutation" : string.Empty) + selection });
        var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(_url, content);
        response.EnsureSuccessStatusCode();
        response.Headers.TryGetValues("X-RateLimit-Limit", out var rateLimitValues);
        response.Headers.TryGetValues("X-RateLimit-Remaining", out var rateRemainingValues);
        var rateLimitString = rateLimitValues?.FirstOrDefault();
        var rateRemainingString = rateRemainingValues?.FirstOrDefault();
        var rateLimitValidated = int.TryParse(rateLimitString, out var rateLimit);
        var rateRemainingValidated = int.TryParse(rateRemainingString, out var rateRemaining);
        if (rateLimitValidated && rateRemainingValidated)
            RateChanged?.Invoke(this, new AniRateEventArgs(rateLimit, rateRemaining));
        var responseContent = await response.Content.ReadAsStringAsync();
        return JObject.Parse(responseContent)["data"];
    }

}