using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Image
{
    /// <summary>
    /// The image of media at its largest size.
    /// </summary>
    [JsonProperty("large")] public Uri LargeImageUrl { get; private set; }
    /// <summary>
    /// The image of media at its medium size.
    /// </summary>
    [JsonProperty("medium")] public Uri MediumImageUrl { get; private set; }
}