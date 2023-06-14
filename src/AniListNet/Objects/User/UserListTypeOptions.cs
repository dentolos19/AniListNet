using Newtonsoft.Json;

namespace AniListNet.Objects;

public class UserListTypeOptions
{
    /// <summary>
    /// The order each list should be displayed in.
    /// </summary>
    [JsonProperty("sectionOrder")] public string[] SectionOrder { get; private set; }

    /// <summary>
    /// If the completed sections of the list should be separated by format.
    /// </summary>
    [JsonProperty("splitCompletedSectionByFormat")] public bool SplitCompletedSectionByFormat { get; private set; }

    /// <summary>
    /// The names of the user's custom lists.
    /// </summary>
    [JsonProperty("customLists")] public string[] CustomLists { get; private set; }

    /// <summary>
    /// The names of the user's advanced scoring sections.
    /// </summary>
    [JsonProperty("advancedScoring")] public string[] AdvancedScoring { get; private set; }

    /// <summary>
    /// If advanced scoring is enabled.
    /// </summary>
    [JsonProperty("advancedScoringEnabled")] public bool IsAdvancedScoringEnabled { get; private set; }
}