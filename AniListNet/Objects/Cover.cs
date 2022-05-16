using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Cover : Image
{

    [JsonProperty("extraLarge")] public Uri ExtraLargeImageUrl { get; private init; }
    [JsonProperty("color")] public string ColorHex { get; private init; }

}