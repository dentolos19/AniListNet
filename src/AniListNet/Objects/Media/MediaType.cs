using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaType
{
    /// <summary>
    /// Japanese Anime
    /// </summary>
    [EnumMember(Value = "ANIME")] Anime,
    /// <summary>
    /// Asian comic
    /// </summary>
    [EnumMember(Value = "MANGA")] Manga
}