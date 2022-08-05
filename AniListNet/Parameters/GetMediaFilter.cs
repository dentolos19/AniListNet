using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class GetMediaFilter
{

    public MediaSort Sort { get; set; } = MediaSort.Popularity;
    public MediaType? Type { get; set; }
    public bool OnList { get; set; }

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>
        {
            new("sort", Sort),
            new("onList", Type)
        };
        if (Type.HasValue)
            parameters.Add(new GqlParameter("type", Type.Value));
        return parameters;
    }

}