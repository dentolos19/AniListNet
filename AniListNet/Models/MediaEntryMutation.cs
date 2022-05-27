using AniListNet.Objects;

namespace AniListNet.Models;

public class MediaEntryMutation
{

    public MediaEntryStatus? Status { get; set; }
    public float? Score { get; set; }
    public int? Progress { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? CompleteDate { get; set; }

    public MediaEntryMutation(MediaEntry? entry = null)
    {
        if (entry == null)
            return;
        Status = entry.Status;
        Score = entry.Score;
        Progress = entry.Progress;
        StartDate = entry.StartDate.ToDateOnly();
        CompleteDate = entry.CompleteDate.ToDateOnly();
    }

}