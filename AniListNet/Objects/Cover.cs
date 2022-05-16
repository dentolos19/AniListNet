using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Cover : Image
{

    // [JsonProperty("color")] private readonly string? _color;

    [JsonProperty("extraLarge")] public Uri ExtraLargeImageUrl { get; private init; }
    // public Color? Color => _color != null ? ColorTranslator.FromHtml(_color) : null;

}