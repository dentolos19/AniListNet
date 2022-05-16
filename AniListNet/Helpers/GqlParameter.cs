namespace AniListNet.Helpers;

internal class GqlParameter
{

    public string Name { get; }
    public object? Value { get; }

    public GqlParameter(string name, object? value)
    {
        Name = name;
        Value = value;
    }

}