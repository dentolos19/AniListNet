using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum CharacterSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "ROLE")] Role,
    [EnumMember(Value = "FAVOURITES")] Favorites,
    [EnumMember(Value = "SEARCH_MATCH")] Relevance
}