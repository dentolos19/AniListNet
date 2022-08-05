namespace AniListNet.Helpers;

internal class GqlSelection
{

    public string Name { get; }
    public IList<GqlSelection>? Selections { get; }
    public IList<GqlParameter>? Parameters { get; }

    public GqlSelection(string name, IEnumerable<GqlSelection>? selections = null, IEnumerable<GqlParameter>? parameters = null)
    {
        Name = name;
        Selections = selections?.ToList();
        Parameters = parameters?.ToList();
    }

    public override string ToString()
    {
        return GqlParser.ParseSelections(this);
    }

}