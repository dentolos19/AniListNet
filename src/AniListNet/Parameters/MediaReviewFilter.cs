using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class MediaReviewFilter
{
    /// <summary>
    /// Filter by review ID.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Filter by media ID.
    /// </summary>
    public int? MediaId { get; set; }

    /// <summary>
    /// Filter by user ID.
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// Filter by media type.
    /// </summary>
    public MediaType? MediaType { get; set; }

    /// <summary>
    /// The order the results will be returned in.
    /// </summary>
    public MediaReviewSort Sort { get; set; } = MediaReviewSort.Rating;

    /// <summary>
    /// Whether the order will be sorted by descending.
    /// </summary>
    public bool SortDescending { get; set; } = true;

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (Id.HasValue)
            parameters.Add(new GqlParameter("id", Id));
        if (MediaId.HasValue)
            parameters.Add(new GqlParameter("mediaId", MediaId));
        if (UserId.HasValue)
            parameters.Add(new GqlParameter("userId", UserId));
        if (MediaType.HasValue)
            parameters.Add(new GqlParameter("mediaType", MediaType));
        parameters.Add(new GqlParameter("sort", $"${HelperUtilities.GetEnumMemberValue(Sort)}" + (SortDescending ? "_DESC" : string.Empty)));
        return parameters;
    }
}