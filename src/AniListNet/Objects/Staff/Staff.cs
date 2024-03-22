using AniListNet.Helpers;

namespace AniListNet.Objects;

public class Staff
{
    /// <summary>
    /// The ID of the staff member.
    /// </summary>
    [GqlSelection("id")] public int Id { get; private set; }

    /// <summary>
    /// The names of the staff member.
    /// </summary>
    [GqlSelection("name")] public Name Name { get; private set; }

    /// <summary>
    /// The primary language of the staff member.
    /// </summary>
    /// <remarks>Current possible values: Japanese, English, Korean, Italian, Spanish, Portuguese, French, German, Hebrew, Hungarian, Chinese, Arabic, Filipino, Catalan, Finnish, Turkish, Dutch, Swedish, Thai, Tagalog, Malaysian, Indonesian, Vietnamese, Nepali, Hindi, or Urdu</remarks>
    [GqlSelection("languageV2")] public string Language { get; private set; }

    /// <summary>
    /// The staff images.
    /// </summary>
    [GqlSelection("image")] public Image Image { get; private set; }

    /// <summary>
    /// A general description of the staff member.
    /// </summary>
    /// <remarks>In markdown format.</remarks>
    [GqlSelection("description")]
    [GqlParameter("asHtml", false)]
    public string? Description { get; private set; }

    /// <summary>
    /// A general description of the staff member.
    /// </summary>
    /// <remarks>In HTML format.</remarks>
    [GqlSelection("description", "descriptionHtml")]
    [GqlParameter("asHtml", true)]
    public string? DescriptionHtml { get; private set; }

    /// <summary>
    /// The person's primary occupations.
    /// </summary>
    [GqlSelection("primaryOccupations")] public string[] PrimaryOccupations { get; private set; }

    /// <summary>
    /// The staff's gender. Usually Male, Female, or Non-binary but can be any string.
    /// </summary>
    [GqlSelection("gender")] public string? Gender { get; private set; }

    /// <summary>
    /// The staff's date of birth.
    /// </summary>
    [GqlSelection("dateOfBirth")] public Date DateOfBirth { get; private set; }

    /// <summary>
    /// The staff's date of death, if applicable.
    /// </summary>
    [GqlSelection("dateOfDeath")] public Date DateOfDeath { get; private set; }

    /// <summary>
    /// The person's age in years.
    /// </summary>
    [GqlSelection("age")] public int? Age { get; private set; } // TODO: Check if age is non-nullable

    /// <summary>
    /// [startYear, endYear] (If the 2nd value is not present staff is still active)
    /// </summary>
    [GqlSelection("yearsActive")] public int[] YearsActive { get; private set; }

    /// <summary>
    /// The persons birthplace or hometown.
    /// </summary>
    [GqlSelection("homeTown")] public string? HomeTown { get; private set; }

    /// <summary>
    /// The URL for the staff page on the AniList website.
    /// </summary>
    [GqlSelection("siteUrl")] public Uri Url { get; private set; }

    /// <summary>
    /// The amount of user's who have favorited the staff member.
    /// </summary>
    [GqlSelection("favourites")] public int Favorites { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// If the staff member is marked as favorite by the currently authenticated user.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("isFavourite")] public bool IsFavorite { get; private set; }

    /// <summary>
    /// If the staff member is blocked from being added to favorites.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("isFavouriteBlocked")] public bool IsFavoriteBlocked { get; private set; }
}