using Newtonsoft.Json;

namespace AniListNet.Objects;

public class CharacterEdge
{
    [JsonProperty("node")] public Character Character { get; private set; }
    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("role")] public CharacterRole Role { get; private set; }
}