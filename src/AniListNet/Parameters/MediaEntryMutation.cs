using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class MediaEntryMutation
{
    public MediaEntryStatus? Status { get; set; }
    public float? Score { get; set; }
    public int? Progress { get; set; }
    public int? VolumeProgress { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompleteDate { get; set; }

    internal IList<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (Status.HasValue)
            parameters.Add(new GqlParameter("status", Status.Value));
        if (Score.HasValue)
            parameters.Add(new GqlParameter("score", Score.Value));
        if (Progress.HasValue)
            parameters.Add(new GqlParameter("progress", Progress.Value));
        if (VolumeProgress.HasValue)
            parameters.Add(new GqlParameter("progressVolumes", VolumeProgress.Value));
        if (StartDate.HasValue)
            parameters.Add(new GqlParameter("startedAt", new GqlParameter[]
            {
                new("year", StartDate.Value.Year),
                new("month", StartDate.Value.Month),
                new("day", StartDate.Value.Day)
            }));
        if (CompleteDate.HasValue)
            parameters.Add(new GqlParameter("completedAt", new List<GqlParameter>
            {
                new("year", CompleteDate.Value.Year),
                new("month", CompleteDate.Value.Month),
                new("day", CompleteDate.Value.Day)
            }));
        return parameters;
    }
}