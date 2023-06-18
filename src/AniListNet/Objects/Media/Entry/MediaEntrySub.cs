using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaEntrySub
{
    [GqlSelection("media")] private readonly Media _media;

    /// <summary>
    /// The ID of the list entry.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The watching/reading status.
    /// </summary>
    [GqlSelection("status")] public MediaEntryStatus Status { get; private set; }

    /// <summary>
    /// The score of the entry.
    /// </summary>
    [GqlSelection("score")] public float Score { get; private set; }

    /// <summary>
    /// The amount of episodes/chapters consumed by the user.
    /// </summary>
    [GqlSelection("progress")] public int Progress { get; private set; }

    /// <summary>
    /// The amount of volumes read by the user.
    /// </summary>
    [GqlSelection("progressVolumes")] public int? VolumeProgress { get; private set; }

    /// <summary>
    /// When the entry was started by the user.
    /// </summary>
    [GqlSelection("startedAt")] public Date StartDate { get; private set; }

    /// <summary>
    /// When the entry was completed by the user.
    /// </summary>
    [GqlSelection("completedAt")] public Date CompleteDate { get; private set; }

    /// <summary>
    /// The max possible progress of the anime or manga.
    /// </summary>
    public int? MaxProgress => _media.Episodes ?? _media.Chapters;

    /* below are properties that are not part of the API */

    /// <summary>
    /// The max possible volume progress of the manga.
    /// </summary>
    public int? MaxVolumeProgress => _media.Volumes;

    private class Media
    {
        [GqlSelection("episodes")] public int? Episodes { get; private set; }
        [GqlSelection("chapters")] public int? Chapters { get; private set; }
        [GqlSelection("volumes")] public int? Volumes { get; private set; }
    }
}