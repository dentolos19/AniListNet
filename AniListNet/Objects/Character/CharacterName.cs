using Newtonsoft.Json;

namespace AniListNet.Objects;

public class CharacterName : Name
{

    [JsonProperty("alternativeSpoiler")] public IReadOnlyList<string> AlternativeSpoilerNames { get; private set; }

}