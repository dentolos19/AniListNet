using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaRecommendationRating
{
    [EnumMember(Value = "NO_RATING")] NoRating,
    [EnumMember(Value = "RATE_UP")] RateUp,
    [EnumMember(Value = "RATE_DOWN")] RateDown
}