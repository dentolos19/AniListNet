using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Name
{

    [JsonProperty("first")] public string FirstName { get; private init; }
    [JsonProperty("middle")] public string? MiddleName { get; private init; }
    [JsonProperty("last")] public string? LastName { get; private init; }
    [JsonProperty("full")] public string FullName { get; private init; }
    [JsonProperty("native")] public string NativeName { get; private init; }
    [JsonProperty("alternative")] public string[]? AlternativeNames { get; private init; }
    [JsonProperty("alternativeSpoiler")] public string[]? AlternativeSpoilerNames { get; private init; }
    [JsonProperty("userPreferred")] public string PreferredName { get; private init; }

}