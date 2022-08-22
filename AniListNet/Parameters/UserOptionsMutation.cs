using AniListNet.Objects;

namespace AniListNet.Parameters;

public class UserOptionsMutation
{

    public UserMediaTitleLanguage MediaTitleLanguage { get; set; }
    public bool DisplayAdultContent { get; set; }
    public UserProfileColor ProfileColor { get; set; }
    public UserStaffNameLanguage StaffNameLanguage { get; set; }

}