using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class MediaSchedulesFilter
{
    public int? MediaId { get; set; }
    public bool NotYetAired { get; set; } = true;
    public DateTime? StartedAfterDate { get; set; }
    public DateTime? EndedBeforeDate { get; set; }
    public MediaScheduleSort Sort { get; set; } = MediaScheduleSort.Time;
    public bool SortDescending { get; set; }

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (MediaId.HasValue)
            parameters.Add(new GqlParameter("mediaId", MediaId.Value));
        if (StartedAfterDate.HasValue)
            parameters.Add(new GqlParameter("airingAt_greater", new DateTimeOffset(StartedAfterDate.Value).ToUnixTimeSeconds()));
        if (EndedBeforeDate.HasValue)
            parameters.Add(new GqlParameter("airingAt_lesser", new DateTimeOffset(EndedBeforeDate.Value).ToUnixTimeSeconds()));
        parameters.Add(new GqlParameter("notYetAired", NotYetAired));
        parameters.Add(new GqlParameter("sort", $"${HelperUtilities.GetEnumMemberValue(Sort)}" + (SortDescending ? "_DESC" : string.Empty)));
        return parameters;
    }
}