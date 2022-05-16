﻿using AniListNet.Helpers;
using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEdge
{

    [JsonProperty("node")] public Media Media { get; private init; }
    [JsonProperty("id")] public string Id { get; private init; }
    [JsonProperty("relationType")] [GqlParameter("version", 2)] public MediaRelation Relation { get; private init; }

}