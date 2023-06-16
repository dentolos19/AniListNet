namespace AniListNet.Helpers;

[AttributeUsage(AttributeTargets.Property |  AttributeTargets.Field, AllowMultiple = false)]
public class GqlSelectionAttribute : Attribute
{
    public string Name { get; set; }
    public string? Alias { get; set; }

    public GqlSelectionAttribute(string name, string? alias = null)
    {
        Name = name;
        Alias = alias;
    }
}