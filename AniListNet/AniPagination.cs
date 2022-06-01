using AniListNet.Objects;

namespace AniListNet;

public class AniPagination<TData>
{

    public int CurrentPageIndex { get; }
    public int LastPageIndex { get; }
    public bool HasNextPage { get; }
    public TData[] Data { get; }

    public AniPagination(PageInfo pageInfo, TData[] data)
    {
        CurrentPageIndex = pageInfo.CurrentPageIndex;
        LastPageIndex = pageInfo.LastPageIndex;
        HasNextPage = pageInfo.HasNextPage;
        Data = data;
    }

}