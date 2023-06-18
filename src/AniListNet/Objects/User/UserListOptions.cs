using AniListNet.Helpers;

namespace AniListNet.Objects;

public class UserListOptions
{
    /// <summary>
    /// The score format the user is using for media list.
    /// </summary>
    [GqlSelection("scoreFormat")] public UserScoreFormat ScoreFormat { get; private set; }

    /// <summary>
    /// The default order list rows should be displayed in.
    /// </summary>
    [GqlSelection("rowOrder")] public string RowOrder { get; private set; }

    /// <summary>
    /// The user's anime list options.
    /// </summary>
    [GqlSelection("animeList")] public UserListTypeOptions AnimeListOptions { get; private set; }

    /// <summary>
    /// The user's manga list options.
    /// </summary>
    [GqlSelection("mangaList")] public UserListTypeOptions MangaListOptions { get; private set; }
}