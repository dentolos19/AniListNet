namespace AniListNet.Helpers;

internal class GqlSelection
{

    public string Name { get; }
    public IList<GqlSelection>? Selections { get; }
    public IList<GqlParameter>? Parameters { get; }

    public GqlSelection(string name, IList<GqlSelection>? selections = null, IList<GqlParameter>? parameters = null)
    {
        Name = name;
        Selections = selections;
        Parameters = parameters;
    }

}