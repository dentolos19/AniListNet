using Newtonsoft.Json;

namespace AniListNet.Objects;

public class UserListOptions
{
    /// <summary>
    /// The score format the user is using for media list.
    /// </summary>
    [JsonProperty("scoreFormat")] public UserScoreFormat ScoreFormat { get; private set; }

    /// <summary>
    /// The default order list rows should be displayed in.
    /// </summary>
    [JsonProperty("rowOrder")] public string RowOrder { get; private set; }

    /// <summary>
    /// The user's anime list options.
    /// </summary>
    [JsonProperty("animeList")] public UserListTypeOptions AnimeListOptions { get; private set; }

    /// <summary>
    /// The user's manga list options.
    /// </summary>
    [JsonProperty("mangaList")] public UserListTypeOptions MangaListOptions { get; private set; }
}