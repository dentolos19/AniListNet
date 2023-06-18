namespace AniListNet.Helpers;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class GqlSelectionAttribute : Attribute
{
    public string Name { get; }
    public string? Alias { get; }

    public GqlSelectionAttribute(string name, string? alias = null)
    {
        Name = name;
        Alias = alias;
    }
}