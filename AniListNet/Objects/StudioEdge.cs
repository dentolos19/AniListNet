using Newtonsoft.Json;

namespace AniListNet.Objects;

public class StudioEdge
{

    [JsonProperty("node")] public Studio Studio { get; private init; }
    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("isMain")] public bool IsMain { get; private init; }

}