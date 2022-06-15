using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Staff
{

    [JsonProperty("languageV2")] public string Language { get; private init; }
    [JsonProperty("primaryOccupations")] public string[] PrimaryOccupations { get; private init; }
    [JsonProperty("dateOfDeath")] public Date DateOfDeath { get; private init; }
    [JsonProperty("yearsActive")] public int[] YearsActive { get; private init; }
    [JsonProperty("homeTown")] public string? HomeTown { get; private init; }

    /* below is properties copied from Character */

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("name")] public Name Name { get; private init; } // but this one is changed from CharacterName to Name
    [JsonProperty("image")] public Image Image { get; private init; }
    [JsonProperty("description")] public string Description { get; private init; }
    [JsonProperty("gender")] public string? Gender { get; private init; }
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private init; }
    [JsonProperty("age")] public string? Age { get; private init; }
    [JsonProperty("favourites")] public int Favorites { get; private init; }

    /* below is properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private init; }

}