using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaTag
{
    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("name")] public string Name { get; private set; }
    [JsonProperty("description")] public string Description { get; private set; }
    [JsonProperty("category")] public string Category { get; private set; }
    [JsonProperty("isGeneralSpoiler")] public bool IsGeneralSpoiler { get; private set; }
    [JsonProperty("isMediaSpoiler")] public bool IsMediaSpoiler { get; private set; }
    [JsonProperty("isAdult")] public bool IsAdult { get; private set; }
}