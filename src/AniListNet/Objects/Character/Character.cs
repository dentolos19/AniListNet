using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Character
{
    /// <summary>
    /// The id of the character
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The names of the character
    /// </summary>
    [JsonProperty("name")] public CharacterName Name { get; private set; }
    /// <summary>
    /// Character image
    /// </summary>
    [JsonProperty("image")] public Image Image { get; private set; }
    /// <summary>
    /// A general description of the character
    /// </summary>
    /// <remarks>In Markdown format</remarks>
    [JsonProperty("description")] [GqlParameter("asHtml", false)] public string? Description { get; private set; }
    /// <summary>
    /// The character's gender. Usually Male, Female, or Non-binary but can be any string.
    /// </summary>
    [JsonProperty("gender")] public string? Gender { get; private set; }
    /// <summary>
    /// The character's birth date
    /// </summary>
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private set; }
    /// <summary>
    /// The character's age. Note this is a string, not an int, it may contain further text and additional ages.
    /// </summary>
    [JsonProperty("age")] public string? Age { get; private set; }
    /// <summary>
    /// The amount of user's who have favourited the character
    /// </summary>
    [JsonProperty("favourites")] public int Favorites { get; private set; }
    /// <summary>
    /// The url for the character page on the AniList website
    /// </summary>
    [JsonProperty("siteUrl")] public string SiteUrl { get; private set; }

    /* below are properties specific for the authenticated user */

    /// <summary>
    /// If the character is marked as favourite by the currently authenticated user
    /// </summary>
    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }
    /// <summary>
    /// If the character is blocked from being added to favourites
    /// </summary>
    [JsonProperty("isFavouriteBlocked")] public bool IsFavoriteBlocked { get; set; }
}