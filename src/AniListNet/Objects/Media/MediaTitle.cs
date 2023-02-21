using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTitle
{
    [JsonProperty("romaji")] public string RomajiTitle { get; private set; }
    [JsonProperty("english")] public string? EnglishTitle { get; private set; }
    [JsonProperty("native")] public string NativeTitle { get; private set; }
    [JsonProperty("userPreferred")] public string PreferredTitle { get; private set; }
}