using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaSource
{
    [EnumMember(Value = "ORIGINAL")] Original,
    [EnumMember(Value = "MANGA")] Manga,
    [EnumMember(Value = "LIGHT_NOVEL")] LightNovel,
    [EnumMember(Value = "VISUAL_NOVEL")] VisualNovel,
    [EnumMember(Value = "VIDEO_GAME")] VideoGame,
    [EnumMember(Value = "OTEHR")] Other,
    [EnumMember(Value = "NOVEL")] Novel, // v2
    [EnumMember(Value = "DOUJINSHI")] Doujinshi, // v2
    [EnumMember(Value = "ANIME")] Anime, // v2
    [EnumMember(Value = "WEB_NOVEL")] WebNovel, // v3
    [EnumMember(Value = "LIVE_ACTION")] LiveAction, // v3
    [EnumMember(Value = "GAME")] Game, // v3
    [EnumMember(Value = "COMIC")] Comic, // v3
    [EnumMember(Value = "MULTIMEDIA_PROJECT")] MultimediaProject, // v3
    [EnumMember(Value = "PICTURE_BOOK")] PictureBook // v3
}