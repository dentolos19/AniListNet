using AniListNet.Helpers;

namespace AniListNet.Objects;

internal class PageInfo
{
    /// <summary>
    /// The total number of items. Note: This value is not guaranteed to be accurate, do not rely on this for logic.
    /// </summary>
    [GqlSelection("total")] public int TotalCount { get; private set; }

    /// <summary>
    /// The count on a page.
    /// </summary>
    [GqlSelection("perPage")] public int PerPageCount { get; private set; }

    /// <summary>
    /// The current page.
    /// </summary>
    [GqlSelection("currentPage")] public int CurrentPageIndex { get; private set; }

    /// <summary>
    /// The last page.
    /// </summary>
    [GqlSelection("lastPage")] public int LastPageIndex { get; private set; }

    /// <summary>
    /// If there is another page.
    /// </summary>
    [GqlSelection("hasNextPage")] public bool HasNextPage { get; private set; }
}