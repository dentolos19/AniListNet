namespace AniListNet.Helpers;

internal static class HelperExtensions
{

    public static IList<GqlSelection> ToSelections(this Type type)
    {
        return GqlParser.ParseType(type);
    }

    internal static KeyValuePair<T[], T[]> SeparateByBooleans<T>(this IDictionary<T, bool> dictionary)
    {
        var includedItems = dictionary.Where(item => item.Value);
        var excludedItems = dictionary.Where(item => !item.Value);
        return new KeyValuePair<T[], T[]>(
            includedItems.Select(item => item.Key).ToArray(),
            excludedItems.Select(item => item.Key).ToArray()
        );
    }

}