using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaCharacterEdge
{
    [JsonProperty("node")] public Media Media { get; private set; }
    [JsonProperty("id")] public string Id { get; private set; }
    [JsonProperty("characterRole")] public string Role { get; private set; }
}