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

}