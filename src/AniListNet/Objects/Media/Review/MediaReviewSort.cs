using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaReviewSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "ID_DESC")] IdDesc,
    [EnumMember(Value = "SCORE")] Score,
    [EnumMember(Value = "SCORE_DESC")] ScoreDesc,
    [EnumMember(Value = "RATING")] Rating,
    [EnumMember(Value = "RATING_DESC")] RatingDesc,
    [EnumMember(Value = "CREATED_AT")] CreatedAt,
    [EnumMember(Value = "CREATED_AT_DESC")] CreatedAtDesc,
    [EnumMember(Value = "UPDATED_AT")] UpdatedAt,
    [EnumMember(Value = "UPDATED_AT_DESC")] UpdatedAtDesc,
}