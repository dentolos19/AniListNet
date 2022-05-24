namespace AniListNet.Helpers;

internal static class GqlExtensions
{

    public static GqlSelection[] ToSelections(this Type type)
    {
        return GqlParser.ParseType(type);
    }

}