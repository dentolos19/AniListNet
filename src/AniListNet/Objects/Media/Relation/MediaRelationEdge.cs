using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaRelationEdge : MediaEdge
{
    [GqlSelection("relationType")] [GqlParameter("version", 2)] public MediaRelation Relation { get; private set; }
}