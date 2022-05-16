namespace AniListNet.Helpers;

internal class GqlSelection
{

    public string Name { get; }
    public GqlSelection[]? Selections { get; }
    public GqlParameter[]? Parameters { get; }

    public GqlSelection(string name, GqlSelection[]? selections = null, GqlParameter[]? parameters = null)
    {
        Name = name;
        Selections = selections;
        Parameters = parameters;
    }

}