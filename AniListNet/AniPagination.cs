using AniListNet.Objects;

namespace AniListNet;

public class AniPagination<T>
{

    public int CurrentPageIndex { get; }
    public int LastPageIndex { get; }
    public bool HasNextPage { get; }
    public T[] Data { get; }

    public AniPagination(PageInfo pageInfo, T[] data)
    {
        CurrentPageIndex = pageInfo.CurrentPageIndex;
        LastPageIndex = pageInfo.LastPageIndex;
        HasNextPage = pageInfo.HasNextPage;
        Data = data;
    }

}