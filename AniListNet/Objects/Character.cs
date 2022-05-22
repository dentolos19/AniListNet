using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Character
{

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("name")] public Name Name { get; private init; }
    [JsonProperty("image")] public Image Image { get; private init; }
    [JsonProperty("description")] public string Description { get; private init; }
    [JsonProperty("gender")] public string? Gender { get; private init; }
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private init; }
    [JsonProperty("age")] public string? Age { get; private init; }
    [JsonProperty("favourites")] public int Favorites { get; private init; }

    /* below is properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private init; }

}