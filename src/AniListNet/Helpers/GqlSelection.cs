namespace AniListNet.Helpers;

internal class GqlSelection
{
    public string Name { get; set; }
    public string? Alias { get; set; }
    public IList<GqlParameter>? Parameters { get; set; }
    public IList<GqlSelection>? Selections { get; set; }

    public GqlSelection(string name)
    {
        Name = name;
    }

    public GqlSelection(string name, IEnumerable<GqlSelection>? selections = null, IEnumerable<GqlParameter>? parameters = null)
    {
        Name = name;
        Selections = selections?.ToList();
        Parameters = parameters?.ToList();
    }

    internal GqlSelection(GqlSelectionAttribute attribute)
    {
        Name = attribute.Name;
        Alias = attribute.Alias;
    }

    public override string ToString()
    {
        return GqlParser.ParseToString(this);
    }
}