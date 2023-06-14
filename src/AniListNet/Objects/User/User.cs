using Newtonsoft.Json;

namespace AniListNet.Objects;

public class User
{
    /// <summary>
    /// The ID of the user.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }

    /// <summary>
    /// The name of the user.
    /// </summary>
    [JsonProperty("name")] public string Name { get; private set; }

    /// <summary>
    /// The bio written by user.
    /// </summary>
    /// <remarks>In markdown format.</remarks>
    [JsonProperty("about")] public string? About { get; private set; }

    /// <summary>
    /// The user's avatar images.
    /// </summary>
    [JsonProperty("avatar")] public Image Avatar { get; private set; }

    /// <summary>
    /// The user's banner images.
    /// </summary>
    [JsonProperty("bannerImage")] public Uri? BannerImageUrl { get; private set; }

    /// <summary>
    /// The user's general options.
    /// </summary>
    [JsonProperty("options")] public UserOptions Options { get; private set; }

    /// <summary>
    /// The user's media list options.
    /// </summary>
    [JsonProperty("listOptions")] public UserListOptions ListOptions { get; private set; }

    /// <summary>
    /// The URL for the user page on the AniList website.
    /// </summary>
    [JsonProperty("siteUrl")] public Uri Url { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the authenticated user if following this user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [JsonProperty("isFollowing")] public bool IsFollowing { get; private set; }

    /// <summary>
    /// If this user if following the authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [JsonProperty("isFollower")] public bool IsFollower { get; private set; }

    /// <summary>
    /// If the user is blocked by the authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [JsonProperty("isBlocked")] public bool IsBlocked { get; private set; }
}