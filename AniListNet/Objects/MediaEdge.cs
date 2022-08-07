using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEdge
{

    [JsonProperty("node")] public Media Media { get; private set; }
    [JsonProperty("id")] public string Id { get; private set; }

}