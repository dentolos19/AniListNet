using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class SearchStaffFilter
{
    public bool? IsBirthday { get; set; }
    public string? Query { get; set; }
    public StaffSort Sort { get; set; } = StaffSort.Relevance;
    public bool SortDescending { get; set; } = true;

    internal IList<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (IsBirthday.HasValue)
            parameters.Add(new GqlParameter("isBirthday", IsBirthday));
        if (!string.IsNullOrEmpty(Query))
            parameters.Add(new GqlParameter("search", Query));
        parameters.Add(
            new GqlParameter(
                "sort",
                $"${HelperUtilities.GetEnumMemberValue(Sort)}" +
                (SortDescending && Sort != StaffSort.Relevance ? "_DESC" : string.Empty)
            )
        );
        return parameters;
    }
}