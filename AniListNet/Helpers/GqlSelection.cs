namespace AniListNet.Helpers;

internal class GqlSelection
{

    public string Name { get; }
    public GqlSelection[]? Selections { get; internal set; }
    public GqlParameter[]? Parameters { get; internal set; }

    public GqlSelection(string name, GqlSelection[]? selections = null, GqlParameter[]? parameters = null)
    {
        Name = name;
        Selections = selections;
        Parameters = parameters;
    }

}