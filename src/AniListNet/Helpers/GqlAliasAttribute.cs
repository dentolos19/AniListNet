namespace AniListNet.Helpers;

internal class GqlAliasAttribute : Attribute
{
    public string Alias { get; }
    public string AliasFor { get; }

    public GqlAliasAttribute(string alias, string aliasFor)
    {
        Alias = alias;
        AliasFor = aliasFor;
    }
}