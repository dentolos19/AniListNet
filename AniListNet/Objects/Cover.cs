using System.Drawing;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Cover : Image
{

    [JsonProperty("color")] private readonly string? _color;

    [JsonProperty("extraLarge")] public Uri ExtraLargeImageUrl { get; private set; }

    public Color Color => _color != null ? (Color)new ColorConverter().ConvertFromString(_color) : Color.Empty;

}