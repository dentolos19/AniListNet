using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Staff
{
    /// <summary>
    /// The ID of the staff member.
    /// </summary>
    [JsonProperty("id")] public int Id { get; private set; }

    /// <summary>
    /// The names of the staff member.
    /// </summary>
    [JsonProperty("name")] public Name Name { get; private set; }

    /// <summary>
    /// The primary language of the staff member.
    /// </summary>
    /// <remarks>Current possible values: Japanese, English, Korean, Italian, Spanish, Portuguese, French, German, Hebrew, Hungarian, Chinese, Arabic, Filipino, Catalan, Finnish, Turkish, Dutch, Swedish, Thai, Tagalog, Malaysian, Indonesian, Vietnamese, Nepali, Hindi, or Urdu</remarks>
    [JsonProperty("languageV2")] public string Language { get; private set; }

    /// <summary>
    /// The staff images.
    /// </summary>
    [JsonProperty("image")] public Image Image { get; private set; }

    /// <summary>
    /// A general description of the staff member.
    /// </summary>
    [JsonProperty("description")] [GqlParameter("asHtml", false)] public string? Description { get; private set; }

    /// <summary>
    /// The person's primary occupations.
    /// </summary>
    [JsonProperty("primaryOccupations")] public string[] PrimaryOccupations { get; private set; }

    /// <summary>
    /// The staff's gender. Usually Male, Female, or Non-binary but can be any string.
    /// </summary>
    [JsonProperty("gender")] public string? Gender { get; private set; }

    /// <summary>
    /// The staff's date of birth.
    /// </summary>
    [JsonProperty("dateOfBirth")] public Date DateOfBirth { get; private set; }

    /// <summary>
    /// The staff's date of death, if applicable.
    /// </summary>
    [JsonProperty("dateOfDeath")] public Date DateOfDeath { get; private set; }

    /// <summary>
    /// The person's age in years.
    /// </summary>
    [JsonProperty("age")] public int? Age { get; private set; } // TODO: check if age is non-nullable

    /// <summary>
    /// [startYear, endYear] (If the 2nd value is not present staff is still active)
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

    /// <summary>
    /// The amount of user's who have favorited the staff member.
    /// </summary>
    [JsonProperty("favourites")] public int Favorites { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the staff member is marked as favorite by the currently authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [JsonProperty("isFavourite")] public bool IsFavorite { get; private set; }

    /// <summary>
    /// If the staff member is blocked from being added to favorites.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [JsonProperty("isFavouriteBlocked")] public bool IsFavoriteBlocked { get; set; }
}