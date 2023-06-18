using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaTitle
{
    /// <summary>
    /// The romanization of the native language title.
    /// </summary>
    [GqlSelection("romaji")] public string RomajiTitle { get; private set; }

    /// <summary>
    /// The official english title.
    /// </summary>
    [GqlSelection("english")] public string? EnglishTitle { get; private set; }

    /// <summary>
    /// Official title in it's native language.
    /// </summary>
    [GqlSelection("native")] public string NativeTitle { get; private set; }

    /// <summary>
    /// The currently authenticated users preferred title language. Default romaji for non-authenticated.
    /// </summary>
    [GqlSelection("userPreferred")] public string PreferredTitle { get; private set; }
}