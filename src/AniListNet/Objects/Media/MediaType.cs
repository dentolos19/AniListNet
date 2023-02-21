using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaType
{
    [EnumMember(Value = "ANIME")] Anime,
    [EnumMember(Value = "MANGA")] Manga
}