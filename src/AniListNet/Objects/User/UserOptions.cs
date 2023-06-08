using Newtonsoft.Json;

namespace AniListNet.Objects;

public class UserOptions
{
    /// <summary>
    /// The language the user wants to see media titles in.
    /// </summary>
    [JsonProperty("titleLanguage")] public UserMediaTitleLanguage MediaTitleLanguage { get; set; }
    /// <summary>
    /// Whether the user has enabled viewing of 18+ content.
    /// </summary>
    [JsonProperty("displayAdultContent")] public bool DisplayAdultContent { get; set; }
    /// <summary>
    /// Whether the user receives notifications when a show they are watching aires.
    /// </summary>
    [JsonProperty("airingNotifications")] public bool ReceiveAiringNotifications { get; set; }
    /// <summary>
    /// Profile highlight color.
    /// </summary>
    /// <remarks>Possible values: blue, purple, pink, orange, red, green, gray, or a hex value.</remarks>
    [JsonProperty("profileColor")] public string ProfileColor { get; set; }
    /// <summary>
    /// The language the user wants to see staff and character names in.
    /// </summary>
    [JsonProperty("staffNameLanguage")] public UserStaffNameLanguage StaffNameLanguage { get; set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// The user's timezone offset.
    /// </summary>
    [JsonProperty("timezone")] public string? Timezone { get; set; }
}