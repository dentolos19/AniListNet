using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaSort
{
    [EnumMember(Value = "SEARCH_MATCH")] Relevance,
    [EnumMember(Value = "SCORE")] Score,
    [EnumMember(Value = "POPULARITY")] Popularity,
    [EnumMember(Value = "TRENDING")] Trending,
    [EnumMember(Value = "FAVOURITES")] Favorites,
    [EnumMember(Value = "TYPE")] Type,
    [EnumMember(Value = "FORMAT")] Format,
    [EnumMember(Value = "STATUS")] Status
    // TODO: update with more sort options: https://anilist.github.io/ApiV2-GraphQL-Docs/
}