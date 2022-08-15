using Newtonsoft.Json;

namespace AniListNet.Objects;

public class UserOptions
{

    [JsonProperty("titleLanguage")] public UserTitleLanguage TitleLanguage { get; set; }
    [JsonProperty("displayAdultContent")] public bool DisplayAdultContent { get; set; }
    [JsonProperty("airingNotifications")] public bool AiringNotifications { get; set; }
    [JsonProperty("profileColor")] public UserProfileColor ProfileColor { get; set; }
    [JsonProperty("staffNameLanguage")] public UserStaffNameLanguage StaffNameLanguage { get; set; }

}