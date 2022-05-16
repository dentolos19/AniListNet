using AniListNet.Objects;

namespace AniListNet;

public class AniFilter
{

    public string? Query { get; init; }
    public MediaSort Sort { get; init; } = MediaSort.Relevance;
    public MediaType? Type { get; init; }

}