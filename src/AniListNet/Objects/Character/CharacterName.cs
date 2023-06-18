using AniListNet.Helpers;

namespace AniListNet.Objects;

public class CharacterName : Name
{
    /// <summary>
    /// Other names the character might be referred to as but are spoilers.
    /// </summary>
    [GqlSelection("alternativeSpoiler")] public string[] AlternativeSpoilerNames { get; private set; }
}