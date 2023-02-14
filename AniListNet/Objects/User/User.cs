using Newtonsoft.Json;

namespace AniListNet.Objects;

public class User
{

    [JsonProperty("id")] public int Id { get; private set; }
    [JsonProperty("name")] public string Name { get; private set; }
    [JsonProperty("about")] public string? About { get; private set; }
    [JsonProperty("avatar")] public Image Avatar { get; private set; }
    [JsonProperty("bannerImage")] public Uri? BannerImageUrl { get; private set; }
    [JsonProperty("options")] public UserOptions Options { get; private set; }
    [JsonProperty("siteUrl")] public Uri Url { get; private set; }
    
    /* below are properties specific for the authenticated user */

    [JsonProperty("isFollowing")] public bool IsFollowing { get; private set; }
    [JsonProperty("isFollower")] public bool IsFollower { get; private set; }

}