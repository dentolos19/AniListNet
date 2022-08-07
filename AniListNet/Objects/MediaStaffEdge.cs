using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaStaffEdge : MediaEdge
{

    [JsonProperty("staffRole")] public string Role { get; private set; }

}