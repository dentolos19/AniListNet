using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Image
{
    /// <summary>
    /// The image URL at large size.
    /// </summary>
    [JsonProperty("large")] public Uri LargeImageUrl { get; private set; }

    /// <summary>
    /// The image URL at medium size.
    /// </summary>
    [JsonProperty("medium")] public Uri MediumImageUrl { get; private set; }
}