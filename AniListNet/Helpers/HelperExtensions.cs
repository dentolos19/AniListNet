namespace AniListNet.Helpers;

internal static class HelperExtensions
{

    public static IList<GqlSelection> ToSelections(this Type type)
    {
        return GqlParser.ParseType(type);
    }

    internal static KeyValuePair<TObject[], TObject[]> SeparateByBooleans<TObject>(this IDictionary<TObject, bool> dictionary)
    {
        var includedItems = dictionary.Where(item => item.Value);
        var excludedItems = dictionary.Where(item => !item.Value);
        return new KeyValuePair<TObject[], TObject[]>(
            includedItems.Select(item => item.Key).ToArray(),
            excludedItems.Select(item => item.Key).ToArray()
        );
    }

}