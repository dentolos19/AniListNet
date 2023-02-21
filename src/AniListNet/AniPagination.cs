using AniListNet.Objects;

namespace AniListNet;

public class AniPagination<TData>
{
    public int TotalCount { get; }
    public int PerPageCount { get; }
    public int CurrentPageIndex { get; }
    public int LastPageIndex { get; }
    public bool HasNextPage { get; }
    public TData[] Data { get; }

    internal AniPagination(PageInfo pageInfo, TData[] data)
    {
        TotalCount = pageInfo.TotalCount;
        PerPageCount = pageInfo.PerPageCount;
        CurrentPageIndex = pageInfo.CurrentPageIndex;
        LastPageIndex = pageInfo.LastPageIndex;
        HasNextPage = pageInfo.HasNextPage;
        Data = data;
    }
}