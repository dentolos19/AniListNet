namespace AniListNet.Helpers;

internal static class GqlExtensions
{

    public static IList<GqlSelection> ToSelections(this Type type)
    {
        return GqlParser.ParseType(type);
    }

}