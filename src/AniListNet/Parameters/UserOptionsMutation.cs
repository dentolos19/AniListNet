using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class UserOptionsMutation
{
    public UserMediaTitleLanguage? MediaTitleLanguage { get; set; }
    public bool? DisplayAdultContent { get; set; }
    public UserScoreFormat? ScoreFormat { get; set; }
    public string? RowOrder { get; set; }
    public string? ProfileColor { get; set; }
    public UserListOptionsMutation? AnimeListOptions { get; set; }
    public UserListOptionsMutation? MangaListOptions { get; set; }
    public UserStaffNameLanguage? StaffNameLanguage { get; set; }

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (MediaTitleLanguage.HasValue)
            parameters.Add(new GqlParameter("titleLanguage", MediaTitleLanguage));
        if (DisplayAdultContent.HasValue)
            parameters.Add(new GqlParameter("displayAdultContent", DisplayAdultContent));
        if (ScoreFormat.HasValue)
            parameters.Add(new GqlParameter("scoreFormat", ScoreFormat));
        if (!string.IsNullOrEmpty(RowOrder))
           parameters.Add(new GqlParameter("rowOrder", RowOrder));
        if (!string.IsNullOrEmpty(ProfileColor))
            parameters.Add(new GqlParameter("profileColor", ProfileColor));
        if (AnimeListOptions is not null)
            parameters.Add(new GqlParameter("animeListOptions", AnimeListOptions.ToParameters()));
        if (MangaListOptions is not null)
            parameters.Add(new GqlParameter("mangaListOptions", MangaListOptions.ToParameters()));
        if (StaffNameLanguage.HasValue)
            parameters.Add(new GqlParameter("staffNameLanguage", StaffNameLanguage));
        return parameters;
    }
}