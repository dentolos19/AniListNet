using Newtonsoft.Json;

namespace AniListNet.Objects;

public class UserOptions
{
    /// <summary>
    /// The language the user wants to see media titles in
    /// </summary>
    [JsonProperty("titleLanguage")] public UserMediaTitleLanguage MediaTitleLanguage { get; set; }
    /// <summary>
    /// Whether the user has enabled viewing of 18+ content
    /// </summary>
    [JsonProperty("displayAdultContent")] public bool DisplayAdultContent { get; set; }
    /// <summary>
    /// Whether the user receives notifications when a show they are watching aires
    /// </summary>
    [JsonProperty("airingNotifications")] public bool ReceiveAiringNotifications { get; set; }
    /// <summary>
    /// Profile highlight color (blue, purple, pink, orange, red, green, gray)
    /// </summary>
    /// <remarks>Some users may have non standard colors and will default to Custom</remarks>
    [JsonProperty("profileColor")] public UserProfileColor ProfileColor { get; set; }
    /// <summary>
    /// The language the user wants to see staff and character names in
    /// </summary>
    [JsonProperty("staffNameLanguage")] public UserStaffNameLanguage StaffNameLanguage { get; set; }
    
    /* below are properties specific for the authenticated user */
    
    /// <summary>
    /// The user's timezone offset (Auth user only)
    /// </summary>
    [JsonProperty("timezone")] public string? Timezone { get; set; }
}