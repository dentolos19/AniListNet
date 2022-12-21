using Newtonsoft.Json;

namespace AniListNet.Objects;

internal class PageInfo
{

    [JsonProperty("total")] public int TotalCount { get; private set; }
    [JsonProperty("perPage")] public int PerPageCount { get; private set; }
    [JsonProperty("currentPage")] public int CurrentPageIndex { get; private set; }
    [JsonProperty("lastPage")] public int LastPageIndex { get; private set; }
    [JsonProperty("hasNextPage")] public bool HasNextPage { get; private set; }

}