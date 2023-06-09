using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class MediaTrendFilter
{
    public int? MediaId { get; set; }
    public DateTime? Date { get; set; }
    public int? Trending { get; set; }
    public int? Popularity { get; set; }
    public int? Episode { get; set; }
    public bool Releasing { get; set; }
    public MediaTrendSort Sort { get; set; } = MediaTrendSort.Popularity;
    public bool SortDescending { get; set; } = true;
    
    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (MediaId.HasValue)
            parameters.Add(new GqlParameter("mediaId", MediaId));
        if (Trending.HasValue)
            parameters.Add(new GqlParameter("trending", Trending));
        if (Popularity.HasValue)
            parameters.Add(new GqlParameter("popularity", Popularity));
        if (Episode.HasValue)
            parameters.Add(new GqlParameter("episode", Episode));
        if (Releasing)
            parameters.Add(new GqlParameter("releasing", Releasing));
        if (Date.HasValue)
            parameters.Add(new GqlParameter("date", new DateTimeOffset(Date.Value).ToUnixTimeSeconds()));
        
        parameters.Add(new GqlParameter("sort", $"${HelperUtilities.GetEnumMemberValue(Sort)}" + (SortDescending ? "_DESC" : string.Empty)));
        return parameters;
    }
}