using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Models;

public class SearchMediaFilter
{

    public MediaSeason? Season { get; set; }
    public int SeasonYear { get; set; } = DateTime.Now.Year;
    public MediaType? Type { get; set; }
    public bool? IsAdult { get; set; }
    public bool? OnList { get; set; }
    public string? Query { get; set; }
    public IDictionary<MediaFormat, bool> Format { get; set; } = new Dictionary<MediaFormat, bool>();
    public IDictionary<MediaStatus, bool> Status { get; set; } = new Dictionary<MediaStatus, bool>();
    public IDictionary<string, bool> Genres { get; set; } = new Dictionary<string, bool>();
    public IDictionary<int, bool> Tags { get; set; } = new Dictionary<int, bool>();
    public MediaSort Sort { get; set; } = MediaSort.Relevance;

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (Season != null)
            parameters.AddRange(new GqlParameter[]
            {
                new("season", Season),
                new("seasonYear", SeasonYear)
            });
        if (Type != null)
            parameters.Add(new GqlParameter("type", Type));
        if (IsAdult != null)
            parameters.Add(new GqlParameter("isAdult", IsAdult));
        if (OnList != null)
            parameters.Add(new GqlParameter("onList", OnList));
        if (!string.IsNullOrEmpty(Query))
            parameters.Add(new GqlParameter("search", Query));
        if (Format is { Count: > 0 })
        {
            var (includedItems, excludedItems) = Format.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("format_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("format_not_in", excludedItems));
        }
        if (Status is { Count: > 0 })
        {
            var (includedItems, excludedItems) = Status.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("status_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("status_not_in", excludedItems));
        }
        if (Genres is { Count: > 0 })
        {
            var (includedItems, excludedItems) = Genres.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("genre_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("genre_not_in", excludedItems));
        }
        if (Tags is { Count: > 0 })
        {
            var (includedItems, excludedItems) = Tags.SeparateByBooleans();
            if (includedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("tag_in", includedItems));
            if (excludedItems is { Length: > 0 })
                parameters.Add(new GqlParameter("tag_not_in", excludedItems));
        }
        return parameters;
    }

}