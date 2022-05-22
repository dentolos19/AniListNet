using AniListNet.Objects;

namespace AniListNet;

public class AniFilter
{

    public MediaSeason? Season { get; init; }
    public int SeasonYear { get; init; } = DateTime.Now.Year;
    public MediaType? Type { get; init; }
    public string? Query { get; init; }
    public string[]? Genres { get; init; }
    public MediaSort Sort { get; init; } = MediaSort.Relevance;

}