using System.Drawing;
using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaCover : Image
{
    [GqlSelection("color")] private readonly string? _color;

    /// <summary>
    /// The cover image URL of the media at its largest size. If this size isn't available, large will be provided instead.
    /// </summary>
    [GqlSelection("extraLarge")] public Uri ExtraLargeImageUrl { get; private set; }

    /// <summary>
    /// Average hex color of cover image.
    /// </summary>
    public Color Color => _color != null ? (Color)new ColorConverter().ConvertFromString(_color) : Color.Empty;
}