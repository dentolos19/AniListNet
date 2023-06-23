using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaRelationEdge : MediaEdge
{
    /// <summary>
    /// The type of relation to the parent model.
    /// </summary>
    [GqlSelection("relationType")] [GqlParameter("version", 2)] public MediaRelation Relation { get; private set; }
}