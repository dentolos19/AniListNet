using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaRelationEdge : MediaEdge
{

    [JsonProperty("relationType")] [GqlParameter("version", 2)] public MediaRelation Relation { get; private set; }

}