using AniListNet.Helpers;

namespace AniListNet.Objects;

/// <summary>
/// Media Airing Schedule.
/// </summary>
/// <remarks>We only aim to guarantee that FUTURE airing data is present and accurate.</remarks>
public class MediaSchedule
{
    [GqlSelection("airingAt")] private readonly int _airingAt;

    /// <summary>
    /// The ID of the airing schedule item.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The time the episode airs at.
    /// </summary>
    public DateTime AiringTime => DateTimeOffset.FromUnixTimeSeconds(_airingAt).DateTime;

    /// <summary>
    /// The airing episode number.
    /// </summary>
    [GqlSelection("episode")] public int Episode { get; private set; }

    /// <summary>
    /// The associate media of the airing episode.
    /// </summary>
    [GqlSelection("media")] public Media Media { get; private set; }
}