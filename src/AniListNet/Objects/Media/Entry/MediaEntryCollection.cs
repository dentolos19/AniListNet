using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntryCollection
{
    [JsonProperty("lists")] public MediaEntryList[] Lists { get; private set; }
    [JsonProperty("hasNextChunk")] public bool HasNextChunk { get; private set; }
}