using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Staff
{

    [JsonProperty("languageV2")] public string Language { get; private set; }
    [JsonProperty("primaryOccupations")] public IReadOnlyList<string> PrimaryOccupations { get; private set; }
    [JsonProperty("dateOfDeath")] public Date DateOfDeath { get; private set; }
    [JsonProperty("yearsActive")] public IReadOnlyList<int> YearsActive { get; private set; }
    [JsonProperty("homeTown")] public string? HomeTown { get; private set; }

    /* below are properties copied from Character */

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("name")] public Name Name { get; private set; } // but this one is changed from CharacterName to Name
    [JsonProperty("image")] public Image Image { get; private set; }
    [JsonProperty("description")] public string Description { get; private set; }
    [JsonProperty("gender")] public string? Gender { get; private set; }
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private set; }
    [JsonProperty("age")] public string? Age { get; private set; }
    [JsonProperty("favourites")] public int Favorites { get; private set; }

    /* below are properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }

}