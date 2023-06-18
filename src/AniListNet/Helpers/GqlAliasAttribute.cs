namespace AniListNet.Helpers;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
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