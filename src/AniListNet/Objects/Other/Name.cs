using AniListNet.Helpers;

namespace AniListNet.Objects;

public class Name
{
    /// <summary>
    /// The character's/staff member's given name.
    /// </summary>
    [GqlSelection("first")] public string? FirstName { get; private set; }

    /// <summary>
    /// The character's/staff member's middle name.
    /// </summary>
    [GqlSelection("middle")] public string? MiddleName { get; private set; }

    /// <summary>
    /// The character's/staff member's last name.
    /// </summary>
    [GqlSelection("last")] public string? LastName { get; private set; }

    /// <summary>
    /// The character's/staff member's first and last name.
    /// </summary>
    [GqlSelection("full")] public string? FullName { get; private set; }

    /// <summary>
    /// Other names the character/staff member might be referred to as.
    /// </summary>
    [GqlSelection("alternative")] public string[] AlternativeNames { get; private set; }

    /* below are properties only for the authenticated user */

    /// <summary>
    /// The currently authenticated users preferred name language. Default romaji for non-authenticated.
    /// </summary>
    /// <remarks>Requires user authentication with AniList!</remarks>
    [GqlSelection("userPreferred")] public string UserPreferred { get; private set; }
}