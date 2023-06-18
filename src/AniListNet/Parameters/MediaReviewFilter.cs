using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class MediaReviewFilter
{
    public MediaReviewSort Sort { get; set; } = MediaReviewSort.Rating;
    public bool SortDescending { get; set; } = true;

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>
        {
            new("sort", $"${HelperUtilities.GetEnumMemberValue(Sort)}" + (SortDescending ? "_DESC" : string.Empty))
        };
        return parameters;
    }
}