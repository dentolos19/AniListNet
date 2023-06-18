using System.Collections;
using AniListNet.Helpers;

namespace AniListNet;

public class AniPaginationOptions
{
    public int PageIndex { get; }
    public int PageSize { get; }

    public AniPaginationOptions(int pageIndex = 1, int pageSize = 20)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    internal IList<GqlParameter> ToParameters()
    {
        return new GqlParameter[]
        {
            new("page", PageIndex),
            new("perPage", PageSize)
        };
    }
}