using System.Net.Http.Headers;
using AniListNet.Helpers;
using AniListNet.Models;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public bool IsAuthenticated { get; private set; }

    public async Task<bool> TryAuthenticateAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        try
        {
            _ = await GetAuthenticatedUserAsync();
            IsAuthenticated = true;
        }
        catch
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            IsAuthenticated = false;
        }
        return IsAuthenticated;
    }

    public async Task<User> GetAuthenticatedUserAsync()
    {
        var response = await PostRequestAsync(new GqlSelection("Viewer", GqlParser.ParseType(typeof(User))));
        return response["Viewer"].ToObject<User>();
    }

    public async Task<MediaEntry> SaveMediaEntryAsync(int id, MediaEntryMutation mutation)
    {
        var parameters = new List<GqlParameter> { new("mediaId", id) };
        if (mutation.Status.HasValue)
            parameters.Add(new GqlParameter("status", mutation.Status.Value));
        if (mutation.Score.HasValue)
            parameters.Add(new GqlParameter("score", mutation.Score.Value));
        if (mutation.Progress.HasValue)
            parameters.Add(new GqlParameter("progress", mutation.Progress.Value));
        if (mutation.StartDate.HasValue)
            parameters.Add(new GqlParameter("startedAt", new GqlParameter[]
            {
                new("year", mutation.StartDate.Value.Year),
                new("month", mutation.StartDate.Value.Month),
                new("day", mutation.StartDate.Value.Day)
            }));
        if (mutation.CompleteDate.HasValue)
            parameters.Add(new GqlParameter("completedAt", new GqlParameter[]
            {
                new("year", mutation.CompleteDate.Value.Year),
                new("month", mutation.CompleteDate.Value.Month),
                new("day", mutation.CompleteDate.Value.Day)
            }));
        var response = await PostRequestAsync(new GqlSelection("SaveMediaListEntry", typeof(MediaEntry).ToSelections(), parameters.ToArray()), true);
        return response["SaveMediaListEntry"].ToObject<MediaEntry>();
    }

    public async Task<bool> DeleteMediaEntryAsync(int id)
    {
        var response = await PostRequestAsync(
            new GqlSelection("DeleteMediaListEntry", new GqlSelection[]
            {
                new("deleted")
            }, new GqlParameter[]
            {
                new("id", id)
            }), true);
        return response["DeleteMediaListEntry"]["deleted"].ToObject<bool>();
    }

}