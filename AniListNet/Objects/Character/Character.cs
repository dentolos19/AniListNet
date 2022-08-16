using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Character
{

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("name")] public CharacterName Name { get; private set; }
    [JsonProperty("image")] public Image Image { get; private set; }
    [JsonProperty("description")] public string? Description { get; private set; }
    [JsonProperty("gender")] public string? Gender { get; private set; }
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private set; }
    [JsonProperty("age")] public string? Age { get; private set; }
    [JsonProperty("favourites")] public int Favorites { get; private set; }

    /* below is properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }

}