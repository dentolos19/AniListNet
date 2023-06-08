using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum MediaSource
{
    /// <summary>
    /// An original production not based of another work.
    /// </summary>
    [EnumMember(Value = "ORIGINAL")] Original,
    /// <summary>
    /// Asian comic book.
    /// </summary>
    [EnumMember(Value = "MANGA")] Manga,
    /// <summary>
    /// Written work published in volumes.
    /// </summary>
    [EnumMember(Value = "LIGHT_NOVEL")] LightNovel,
    /// <summary>
    /// Video game driven primary by text and narrative.
    /// </summary>
    [EnumMember(Value = "VISUAL_NOVEL")] VisualNovel,
    /// <summary>
    /// Video game.
    /// </summary>
    [EnumMember(Value = "VIDEO_GAME")] VideoGame,
    /// <summary>
    /// Other.
    /// </summary>
    [EnumMember(Value = "OTEHR")] Other,
    /// <summary>
    /// Written works not published in volumes.
    /// </summary>
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "NOVEL")] Novel,
    /// <summary>
    /// Self-published works.
    /// </summary>
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "DOUJINSHI")] Doujinshi,
    /// <summary>
    /// Japanese Anime.
    /// </summary>
    /// <remarks>Version 2 only</remarks>
    [EnumMember(Value = "ANIME")] Anime,
    /// <summary>
    /// Written works published online.
    /// </summary>
    /// <remarks>Version 3 only</remarks>
    [EnumMember(Value = "WEB_NOVEL")] WebNovel,
    /// <summary>
    /// Live action media such as movies or TV show.
    /// </summary>
    /// <remarks>Version 3 only</remarks>
    [EnumMember(Value = "LIVE_ACTION")] LiveAction,
    /// <summary>
    /// Games excluding video games.
    /// </summary>
    /// <remarks>Version 3 only</remarks>
    [EnumMember(Value = "GAME")] Game,
    /// <summary>
    /// Comics excluding manga.
    /// </summary>
    /// <remarks>Version 3 only</remarks>
    [EnumMember(Value = "COMIC")] Comic,
    /// <summary>
    /// Multimedia project.
    /// </summary>
    /// <remarks>Version 3 only</remarks>
    [EnumMember(Value = "MULTIMEDIA_PROJECT")] MultimediaProject,
    /// <summary>
    /// Picture book.
    /// </summary>
    /// <remarks>Version 3 only</remarks>
    [EnumMember(Value = "PICTURE_BOOK")] PictureBook
}