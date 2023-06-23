using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class SearchUserFilter
{
    public bool? IsModerator { get; set; }
    public string? Query { get; set; }
    public UserSort Sort { get; set; } = UserSort.Relevance;
    public bool SortDescending { get; set; } = true;

    internal IList<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (IsModerator.HasValue)
            parameters.Add(new GqlParameter("isModerator", IsModerator));
        if (!string.IsNullOrEmpty(Query))
            parameters.Add(new GqlParameter("search", Query));
        parameters.Add(
            new GqlParameter(
                "sort",
                $"${HelperUtilities.GetEnumMemberValue(Sort)}" +
                (SortDescending && Sort != UserSort.Relevance ? "_DESC" : string.Empty)
            )
        );
        return parameters;
    }
}