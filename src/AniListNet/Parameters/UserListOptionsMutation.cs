using AniListNet.Helpers;

namespace AniListNet.Parameters;

public class UserListOptionsMutation
{
    public string[]? SectionOrder { get; set; }
    public bool? SplitCompletedSectionByFormat { get; set; }
    public bool? CustomLists { get; set; }
    public string[]? AdvancedScoring { get; set; }
    public bool? IsAdvancedScoringEnabled { get; set; }
    public string? Theme { get; set; }

    internal IList<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        if (SectionOrder is { Length: > 0 })
            parameters.Add(new GqlParameter("sectionOrder", SectionOrder));
        if (SplitCompletedSectionByFormat.HasValue)
            parameters.Add(new GqlParameter("splitCompletedSectionByFormat", SplitCompletedSectionByFormat));
        if (CustomLists.HasValue)
            parameters.Add(new GqlParameter("customLists", CustomLists));
        if (AdvancedScoring is { Length: > 0 })
            parameters.Add(new GqlParameter("advancedScoring", AdvancedScoring));
        if (IsAdvancedScoringEnabled.HasValue)
            parameters.Add(new GqlParameter("advancedScoringEnabled", IsAdvancedScoringEnabled));
        if (!string.IsNullOrEmpty(Theme))
            parameters.Add(new GqlParameter("theme", Theme));
        return parameters;
    }
}