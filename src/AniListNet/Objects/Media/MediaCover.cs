using System.Drawing;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaCover : Image
{
    [JsonProperty("color")] private readonly string? _color;

    /// <summary>
    /// The cover image url of the media at medium size.
    /// </summary>
    [JsonProperty("medium")] public Uri MediumImageUrl { get; private set; }
    /// <summary>
    /// The cover image url of the media at large size.
    /// </summary>
    [JsonProperty("large")] public Uri LargeImageUrl { get; private set; }
    /// <summary>
    /// The cover image url of the media at its largest size. If this size isn't available, large will be provided instead.
    /// </summary>
    [JsonProperty("extraLarge")] public Uri ExtraLargeImageUrl { get; private set; }
    /// <summary>
    /// Average hexadecimal color of cover image.
    /// </summary>
    public Color Color => _color != null ? (Color)new ColorConverter().ConvertFromString(_color) : Color.Empty;
}