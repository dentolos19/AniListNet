﻿using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Image
{

    [JsonProperty("large")] public Uri LargeImageUrl { get; private init; }
    [JsonProperty("medium")] public Uri MediumImageUrl { get; private init; }

}