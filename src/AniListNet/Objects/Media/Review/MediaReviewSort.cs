using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaReviewSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "SCORE")] Score,
    [EnumMember(Value = "RATING")] Rating,
    [EnumMember(Value = "CREATED_AT")] CreatedAt,
    [EnumMember(Value = "UPDATED_AT")] UpdatedAt,
}