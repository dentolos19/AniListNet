using AniListNet.Helpers;

namespace AniListNet.Objects;

public class Image
{
    /// <summary>
    /// The image's URL at large size.
    /// </summary>
    [GqlSelection("large")] public Uri LargeImageUrl { get; private set; }

    /// <summary>
    /// The image's URL at medium size.
    /// </summary>
    [GqlSelection("medium")] public Uri MediumImageUrl { get; private set; }
}