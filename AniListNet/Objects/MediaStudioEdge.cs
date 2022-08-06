using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaStudioEdge
{

    [JsonProperty("node")] public Media Media { get; private set; }
    [JsonProperty("id")] public string Id { get; private set; }
    [JsonProperty("isMainStudio")] public bool IsMainStudio { get; private set; }

}