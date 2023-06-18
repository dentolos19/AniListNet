namespace AniListNet.Helpers;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
internal class GqlParameterAttribute : Attribute
{
    public string Name { get; }
    public object? Value { get; }

    public GqlParameterAttribute(string name, object? value)
    {
        Name = name;
        Value = value;
    }
}