using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum StaffSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "ROLE")] Role,
    [EnumMember(Value = "LANGUAGE")] Language,
    [EnumMember(Value = "SEARCH_MATCH")] Relevance,
    [EnumMember(Value = "FAVOURITES")] Favorites
}