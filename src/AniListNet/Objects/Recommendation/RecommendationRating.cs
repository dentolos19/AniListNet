using System.Runtime.Serialization;

namespace AniListNet.Objects.Recommendation;

public enum RecommendationRating
{
    [EnumMember(Value = "NO_RATING")] NO_RATING,
    [EnumMember(Value = "RATE_UP")] RATE_UP,
    [EnumMember(Value = "RATE_DOWN")] RATE_DOWN
}