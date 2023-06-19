namespace AniListNet.Helpers;

internal static class HelperExtensions
{
    public static (TObject[], TObject[]) SeparateByBooleans<TObject>(this IDictionary<TObject, bool> dictionary)
    {
        var includedItems = dictionary.Where(item => item.Value);
        var excludedItems = dictionary.Where(item => !item.Value);
        return (
            includedItems.Select(item => item.Key).ToArray(),
            excludedItems.Select(item => item.Key).ToArray()
        );
    }
}