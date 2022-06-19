using AniListNet.Objects;

namespace AniListNet.Models;

public class MediaEntryMutation
{

    public MediaEntryStatus? Status { get; set; }
    public float? Score { get; set; }
    public int? Progress { get; set; }
    public int? VolumeProgress { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompleteDate { get; set; }

    public MediaEntryMutation(MediaEntry? entry = null)
    {
        if (entry == null)
            return;
        Status = entry.Status;
        Score = entry.Score;
        Progress = entry.Progress;
        VolumeProgress = entry.VolumeProgress;
        StartDate = entry.StartDate.ToDateTime();
        CompleteDate = entry.CompleteDate.ToDateTime();
    }

}