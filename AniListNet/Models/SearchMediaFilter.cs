using AniListNet.Objects;

namespace AniListNet.Models;

public class SearchMediaFilter
{

    public MediaSeason? Season { get; set; }
    public int SeasonYear { get; set; } = DateTime.Now.Year;
    public MediaType? Type { get; set; }
    public string? Query { get; set; }
    public IList<string>? Genres { get; set; } = new List<string>();
    public MediaSort Sort { get; set; } = MediaSort.Relevance;

}