using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaStaffEdge
{

    [JsonProperty("node")] public Media Media { get; private set; }
    [JsonProperty("id")] public string Id { get; private set; }
    [JsonProperty("staffRole")] public string Role { get; private set; }

}