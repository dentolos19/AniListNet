using AniListNet.Helpers;

namespace AniListNet.Objects;

public class UserOptions
{
    /// <summary>
    /// The language the user wants to see media titles in.
    /// </summary>
    [GqlSelection("titleLanguage")] public UserMediaTitleLanguage MediaTitleLanguage { get; private set; }

    /// <summary>
    /// Whether the user has enabled viewing of 18+ content.
    /// </summary>
    [GqlSelection("displayAdultContent")] public bool DisplayAdultContent { get; private set; }

    /// <summary>
    /// Whether the user receives notifications when a show they are watching aires.
    /// </summary>
    [GqlSelection("airingNotifications")] public bool ReceiveAiringNotifications { get; private set; }

    /// <summary>
    /// Profile highlight color.
    /// </summary>
    /// <remarks>Current possible values: blue, purple, pink, orange, red, green, gray, or a hex value.</remarks>
    [GqlSelection("profileColor")] public string ProfileColor { get; private set; }

    /// <summary>
    /// The language the user wants to see staff and character names in.
    /// </summary>
    [GqlSelection("staffNameLanguage")] public UserStaffNameLanguage StaffNameLanguage { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// The user's timezone offset.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("timezone")] public string? Timezone { get; private set; }
}