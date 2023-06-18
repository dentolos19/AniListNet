namespace AniListNet.Helpers;

internal class GqlParameter
{
    public string Name { get; set; }
    public object? Value { get; set; }

    public GqlParameter(string name, object? value)
    {
        Name = name;
        Value = value;
    }

    internal GqlParameter(GqlParameterAttribute attribute)
    {
        Name = attribute.Name;
        Value = attribute.Value;
    }
}