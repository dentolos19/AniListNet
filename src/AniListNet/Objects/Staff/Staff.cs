using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Staff
{
    /// <summary>
    /// The primary language of the staff member.
    /// </summary>
    /// <remarks>Possible values: Japanese, English, Korean, Italian, Spanish, Portuguese, French, German, Hebrew, Hungarian, Chinese, Arabic, Filipino, Catalan, Finnish, Turkish, Dutch, Swedish, Thai, Tagalog, Malaysian, Indonesian, Vietnamese, Nepali, Hindi, or Urdu</remarks>
    [JsonProperty("languageV2")] public string Language { get; private set; }
    /// <summary>
    /// The person's primary occupations.
    /// </summary>
    [JsonProperty("primaryOccupations")] public string[] PrimaryOccupations { get; private set; }
    [JsonProperty("dateOfDeath")] public Date DateOfDeath { get; private set; }
    /// <summary>
    /// [startYear, endYear] (If the 2nd value is not present staff is still active).
    /// </summary>
    [JsonProperty("yearsActive")] public int[] YearsActive { get; private set; }
    /// <summary>
    /// The persons birthplace or hometown.
    /// </summary>
    [JsonProperty("homeTown")] public string? HomeTown { get; private set; }
    /// <summary>
    /// The URL for the staff page on the AniList website.
    /// </summary>
    [JsonProperty("siteUrl")] public Uri Url { get; private set; }

    /* below are properties copied from Character */

    /// <summary>
    /// The ID of the staff member.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }
    /// <summary>
    /// The names of the staff member.
    /// </summary>
    [JsonProperty("name")] public Name Name { get; private set; } // but this one is changed from CharacterName to Name
    /// <summary>
    /// The visual image of the staff member.
    /// </summary>
    [JsonProperty("image")] public Image Image { get; private set; }
    /// <summary>
    /// A general description of the staff member.
    /// </summary>
    [JsonProperty("description")] [GqlParameter("asHtml", false)] public string? Description { get; private set; }
    /// <summary>
    /// The staff's gender. Usually Male, Female, or Non-binary but can be any string.
    /// </summary>
    [JsonProperty("gender")] public string? Gender { get; private set; }
    /// <summary>
    /// The staff's birth date.
    /// </summary>
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private set; }
    /// <summary>
    /// The person's age in years.
    /// </summary>
    [JsonProperty("age")] public string? Age { get; private set; }
    /// <summary>
    /// The amount of user's who have favorite the staff member.
    /// </summary>
    [JsonProperty("favourites")] public int Favorites { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the staff member is marked as favorite by the currently authenticated user.
    /// </summary>
    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }
    /// <summary>
    /// If the staff member is blocked from being added to favorites.
    /// </summary>
    [JsonProperty("isFavouriteBlocked")] public bool IsFavoriteBlocked { get; set; }
}