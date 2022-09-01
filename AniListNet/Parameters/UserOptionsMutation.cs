using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class UserOptionsMutation
{

    public UserMediaTitleLanguage? MediaTitleLanguage { get; set; }
    public bool? DisplayAdultContent { get; set; }
    public UserProfileColor? ProfileColor { get; set; }
    public UserStaffNameLanguage? StaffNameLanguage { get; set; }

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (MediaTitleLanguage.HasValue)
            parameters.Add(new GqlParameter("titleLanguage", MediaTitleLanguage));
        if (DisplayAdultContent.HasValue)
            parameters.Add(new GqlParameter("displayAdultContent", DisplayAdultContent));
        if (ProfileColor.HasValue)
            parameters.Add(new GqlParameter("profileColor", ProfileColor));
        if (StaffNameLanguage.HasValue)
            parameters.Add(new GqlParameter("staffNameLanguage", StaffNameLanguage));
        return parameters;
    }

}