using AniListNet.Objects;

namespace AniListNet;

public class AniFilter
{

    public MediaSeason? Season { get; set; }
    public int SeasonYear { get; set; } = DateTime.Now.Year;
    public MediaType? Type { get; set; }
    public string? Query { get; set; }
    public string[]? Genres { get; set; }
    public MediaSort Sort { get; set; } = MediaSort.Relevance;

}