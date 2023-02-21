using Newtonsoft.Json;

namespace AniListNet.Objects;

public class StudioEdge
{
    [JsonProperty("node")] public Studio Studio { get; private set; }
    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("isMain")] public bool IsMain { get; private set; }
}