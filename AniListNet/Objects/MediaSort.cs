using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaSort
{

    [EnumMember(Value = "SEARCH_MATCH")] Relevance,
    [EnumMember(Value = "SCORE_DESC")] Score,
    [EnumMember(Value = "POPULARITY_DESC")] Popularity,
    [EnumMember(Value = "TRENDING_DESC")] Trending,
    [EnumMember(Value = "FAVOURITES_DESC")] Favorites

}