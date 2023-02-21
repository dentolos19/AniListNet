using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaStudioEdge : MediaEdge
{
    [JsonProperty("isMainStudio")] public bool IsMainStudio { get; private set; }
}