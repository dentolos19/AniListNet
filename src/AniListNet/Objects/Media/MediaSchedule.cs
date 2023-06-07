using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// Media Airing Schedule.
/// </summary>
/// <remarks>We only aim to guarantee that FUTURE airing data is present and accurate.</remarks>
public class MediaSchedule
{
    /// <summary>
    /// The time the episode airs at.
    /// </summary>
    [JsonProperty("airingAt")] private readonly int _airingAt;

    /// <summary>
    /// The id of the airing schedule item.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The airing episode number.
    /// </summary>
    [JsonProperty("episode")] public int Episode { get; private set; }
    /// <summary>
    /// The associate media of the airing episode.
    /// </summary>
    [JsonProperty("media")] public Media Media { get; private set; }

    /// <summary>
    /// The time the episode airs at.
    /// </summary>
    public DateTime AiringTime => DateTimeOffset.FromUnixTimeSeconds(_airingAt).DateTime;
}