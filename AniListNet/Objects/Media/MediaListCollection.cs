using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaListCollection
{
    [JsonProperty("lists")] public MediaList[] Lists { get; private set; }
}