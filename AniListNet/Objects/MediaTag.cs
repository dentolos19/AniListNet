using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTag
{

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("name")] public string Name { get; private init; }
    [JsonProperty("description")] public string Description { get; private init; }
    [JsonProperty("category")] public string Category { get; private init; }
    [JsonProperty("rank")] public int? Rank { get; private init; }
    [JsonProperty("isGeneralSpoiler")] public bool IsGeneralSpoiler { get; private init; }
    [JsonProperty("isMediaSpoiler")] public bool IsMediaSpoiler { get; private init; }
    [JsonProperty("isAdult")] public bool IsAdult { get; private init; }

}