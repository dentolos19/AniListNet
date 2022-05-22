using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Studio
{

    [JsonProperty("id")] public int Id { get; private init; }
    [JsonProperty("name")] public string Name { get; private init; }
    [JsonProperty("isAnimationStudio")] public bool IsAnimationStudio { get; private init; }
    [JsonProperty("favourites")] public int Favorites { get; private init; }

    /* below is properties specific for the authenticated user */

    [JsonProperty("isFavourite")] public bool IsFavorite { get; private init; }

}