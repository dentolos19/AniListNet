using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTitle
{

    [JsonProperty("romaji")] public string RomajiTitle { get; private init; }
    [JsonProperty("english")] public string? EnglishTitle { get; private init; }
    [JsonProperty("native")] public string NativeTitle { get; private init; }
    [JsonProperty("userPreferred")] public string PreferredTitle { get; private init; }

}