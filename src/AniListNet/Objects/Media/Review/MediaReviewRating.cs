using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaReviewRating
{
    [EnumMember(Value = "NO_VOTE")] NoVote,
    [EnumMember(Value = "UP_VOTE")] UpVote,
    [EnumMember(Value = "DOWN_VOTE")] DownVote
}