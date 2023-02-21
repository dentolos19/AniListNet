namespace AniListNet.Helpers;

internal class GqlParameterAttribute : Attribute
{
    public GqlParameter Parameter { get; }

    public GqlParameterAttribute(string name, object? value)
    {
        Parameter = new GqlParameter(name, value);
    }
}