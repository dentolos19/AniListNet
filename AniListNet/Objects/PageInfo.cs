using Newtonsoft.Json;

namespace AniListNet.Objects;

public class PageInfo
{

    [JsonProperty("currentPage")] public int CurrentPageIndex { get; private init; }
    [JsonProperty("lastPage")] public int LastPageIndex { get; private init; }
    [JsonProperty("hasNextPage")] public bool HasNextPage { get; private init; }

}