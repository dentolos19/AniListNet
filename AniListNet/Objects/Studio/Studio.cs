using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Studio
{

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("name")] public string Name { get; private set; }
    [JsonProperty("isAnimationStudio")] public bool IsAnimationStudio { get; private set; }
    [JsonProperty("favourites")] public int Favorites { get; private set; }

    /* below is properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }

}