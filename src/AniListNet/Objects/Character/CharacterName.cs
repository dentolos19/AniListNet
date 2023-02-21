using Newtonsoft.Json;

namespace AniListNet.Objects;

public class CharacterName : Name
{
    [JsonProperty("alternativeSpoiler")] public string[] AlternativeSpoilerNames { get; private set; }
}