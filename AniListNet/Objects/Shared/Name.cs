using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Name
{

    [JsonProperty("first")] public string FirstName { get; private set; }
    [JsonProperty("middle")] public string? MiddleName { get; private set; }
    [JsonProperty("last")] public string? LastName { get; private set; }
    [JsonProperty("full")] public string FullName { get; private set; }
    [JsonProperty("native")] public string NativeName { get; private set; }
    [JsonProperty("alternative")] public string[] AlternativeNames { get; private set; }
    [JsonProperty("userPreferred")] public string PreferredName { get; private set; }

}