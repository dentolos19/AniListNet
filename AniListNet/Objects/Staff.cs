using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Staff : Character
{

    [JsonProperty("languageV2")] public string Language { get; private init; }
    [JsonProperty("primaryOccupations")] public string[] PrimaryOccupations { get; private init; }
    [JsonProperty("dateOfDeath")] public Date DateOfDeath { get; private init; }
    [JsonProperty("yearsActive")] public int[] YearsActive { get; private init; }
    [JsonProperty("homeTown")] public string? HomeTown { get; private init; }

}