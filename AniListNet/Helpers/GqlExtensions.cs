namespace AniListNet.Helpers;

internal static class GqlExtensions
{

    public static GqlSelection AddSelection(this GqlSelection selection, string name)
    {
        var selections = selection.Selections?.ToList() ?? new List<GqlSelection>();
        selections.Add(new GqlSelection(name));
        selection.Selections = selections.ToArray();
        return selection;
    }

    public static GqlSelection[] AddSelection(this GqlSelection[] selection, string name)
    {
        var selections = selection.ToList();
        selections.Add(new GqlSelection(name));
        return selections.ToArray();
    }

    public static GqlSelection AddParameter(this GqlSelection selection, string name, object? value)
    {
        var parameters = selection.Parameters?.ToList() ?? new List<GqlParameter>();
        parameters.Add(new GqlParameter(name, value));
        selection.Parameters = parameters.ToArray();
        return selection;
    }

}