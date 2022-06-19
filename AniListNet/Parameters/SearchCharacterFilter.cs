using AniListNet.Helpers;

namespace AniListNet.Parameters;

public class SearchCharacterFilter
{

    public bool? IsBirthday { get; set; }
    public string? Query { get; set; }

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (IsBirthday.HasValue)
            parameters.Add(new GqlParameter("isBirthday", IsBirthday));
        if (!string.IsNullOrEmpty(Query))
            parameters.Add(new GqlParameter("search", Query));
        return parameters;
    }

}