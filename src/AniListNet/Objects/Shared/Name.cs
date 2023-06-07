using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Name
{
    /// <summary>
    /// The character's given name.
    /// </summary>
    [JsonProperty("first")] public string? FirstName { get; private set; }
    /// <summary>
    /// The character's middle name.
    /// </summary>
    [JsonProperty("middle")] public string? MiddleName { get; private set; }
    /// <summary>
    /// The character's last name.
    /// </summary>
    [JsonProperty("last")] public string? LastName { get; private set; }
    /// <summary>
    /// The character's first and last name.
    /// </summary>
    [JsonProperty("full")] public string? FullName { get; private set; }
    /// <summary>
    /// Other names the character might be referred to as.
    /// </summary>
    [JsonProperty("alternative")] public string[] AlternativeNames { get; private set; }
    
    /* below are properties specific for the authenticated user */
    
    /// <summary>
    /// The currently authenticated users preferred name language. Default romaji for non-authenticated.
    /// </summary>
    [JsonProperty("userPreferred")] public string UserPreferred { get; private set; }
}