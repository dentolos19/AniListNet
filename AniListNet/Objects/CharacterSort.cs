using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum CharacterSort
{

    [EnumMember(Value = "ROLE")] Role,
    [EnumMember(Value = "SEARCH_MATCH")] Relevance,
    [EnumMember(Value = "FAVOURITES")] Favorites

}