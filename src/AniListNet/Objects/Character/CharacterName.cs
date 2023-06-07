using Newtonsoft.Json;

namespace AniListNet.Objects;

public class CharacterName : Name
{
    /// <summary>
    /// Other names the character might be referred to as but are spoilers
    /// </summary>
    [JsonProperty("alternativeSpoiler")] public string[] AlternativeSpoilerNames { get; private set; }
}