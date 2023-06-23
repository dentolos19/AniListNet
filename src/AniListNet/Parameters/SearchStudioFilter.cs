using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class SearchStudioFilter
{
    public string? Query { get; set; }
    public StudioSort Sort { get; set; } = StudioSort.Relevance;
    public bool SortDescending { get; set; } = true;

    internal IList<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (!string.IsNullOrEmpty(Query))
            parameters.Add(new GqlParameter("search", Query));
        parameters.Add(
            new GqlParameter(
                "sort",
                $"${HelperUtilities.GetEnumMemberValue(Sort)}" +
                (SortDescending && Sort != StudioSort.Relevance ? "_DESC" : string.Empty)
            )
        );
        return parameters;
    }
}