using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class GetMediaFilter
{

    public MediaType? Type { get; set; }
    public bool? OnList { get; set; }
    public MediaSort Sort { get; set; } = MediaSort.Popularity;
    public bool SortDescending { get; set; } = true;

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (Type.HasValue)
            parameters.Add(new GqlParameter("type", Type.Value));
        if (OnList.HasValue)
            parameters.Add(new GqlParameter("onList", OnList.Value));
        parameters.Add(new GqlParameter("sort", $"${HelperUtilities.GetEnumMemberValue(Sort)}" + (SortDescending && Sort != MediaSort.Relevance ? "_DESC" : string.Empty)));
        return parameters;
    }

}