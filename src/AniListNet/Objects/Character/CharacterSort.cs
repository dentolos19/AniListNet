using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum CharacterSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "ID_DESC")] IdDesc,
    [EnumMember(Value = "ROLE")] Role,
    [EnumMember(Value = "ROLE_DESC")] RoleDesc,
    [EnumMember(Value = "SEARCH_MATCH")] Relevance,
    [EnumMember(Value = "FAVOURITES")] Favorites,
    [EnumMember(Value = "FAVOURITES_DESC")] FavoritesDesc
}