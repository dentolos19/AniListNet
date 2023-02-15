using Newtonsoft.Json;

namespace AniListNet.Objects;

public class StaffEdge
{
    [JsonProperty("node")] public Staff Staff { get; private set; }
    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("role")] public string Role { get; private set; }
}