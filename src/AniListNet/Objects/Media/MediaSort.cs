using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaSort
{
    [EnumMember(Value = "ID")] Id,
    [EnumMember(Value = "TITLE_ROMAJI")] TitleRomaji,
    [EnumMember(Value = "TITLE_ENGLISH")] TitleEnglish,
    [EnumMember(Value = "TITLE_NATIVE")] TitleNative,
    [EnumMember(Value = "TYPE")] Type,
    [EnumMember(Value = "FORMAT")] Format,
    [EnumMember(Value = "START_DATE")] StartDate,
    [EnumMember(Value = "END_DATE")] EndDate,
    [EnumMember(Value = "SCORE")] Score,
    [EnumMember(Value = "POPULARITY")] Popularity,
    [EnumMember(Value = "TRENDING")] Trending,
    [EnumMember(Value = "EPISODES")] Episodes,
    [EnumMember(Value = "DURATION")] Duration,
    [EnumMember(Value = "STATUS")] Status,
    [EnumMember(Value = "CHAPTERS")] Chapters,
    [EnumMember(Value = "VOLUMES")] Volumes,
    [EnumMember(Value = "UPDATED_AT")] UpdatedAt,
    [EnumMember(Value = "SEARCH_MATCH")] Relevance,
    [EnumMember(Value = "FAVOURITES")] Favorites
}