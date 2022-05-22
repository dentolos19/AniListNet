using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Cover : Image
{

    [JsonProperty("extraLarge")] public Uri ExtraLargeImageUrl { get; private init; }
    [JsonProperty("color")] public string Color { get; private init; } // TODO: simplify data (Color)

}