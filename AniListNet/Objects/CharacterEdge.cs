using Newtonsoft.Json;

namespace AniListNet.Objects;

public class CharacterEdge
{

    [JsonProperty("node")] public Character Character { get; private init; }
    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("role")] public CharacterRole Role { get; private init; }

}