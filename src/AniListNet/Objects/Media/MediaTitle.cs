using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTitle
{
    /// <summary>
    /// The romanization of the native language title.
    /// </summary>
    [JsonProperty("romaji")] public string RomajiTitle { get; private set; }

    /// <summary>
    /// The official english title.
    /// </summary>
    [JsonProperty("english")] public string? EnglishTitle { get; private set; }

    /// <summary>
    /// Official title in it's native language.
    /// </summary>
    [JsonProperty("native")] public string NativeTitle { get; private set; }

    /// <summary>
    /// The currently authenticated users preferred title language. Default romaji for non-authenticated.
    /// </summary>
    [JsonProperty("userPreferred")] public string PreferredTitle { get; private set; }
}