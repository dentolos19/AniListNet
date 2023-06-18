using AniListNet.Helpers;

namespace AniListNet.Objects;

public class UserListTypeOptions
{
    /// <summary>
    /// The order each list should be displayed in.
    /// </summary>
    [GqlSelection("sectionOrder")] public string[] SectionOrder { get; private set; }

    /// <summary>
    /// If the completed sections of the list should be separated by format.
    /// </summary>
    [GqlSelection("splitCompletedSectionByFormat")] public bool SplitCompletedSectionByFormat { get; private set; }

    /// <summary>
    /// The names of the user's custom lists.
    /// </summary>
    [GqlSelection("customLists")] public string[] CustomLists { get; private set; }

    /// <summary>
    /// The names of the user's advanced scoring sections.
    /// </summary>
    [GqlSelection("advancedScoring")] public string[] AdvancedScoring { get; private set; }

    /// <summary>
    /// If advanced scoring is enabled.
    /// </summary>
    [GqlSelection("advancedScoringEnabled")] public bool IsAdvancedScoringEnabled { get; private set; }
}