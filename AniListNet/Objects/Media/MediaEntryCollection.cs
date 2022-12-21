using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntryCollection
{

    [JsonProperty("lists")] public IReadOnlyList<MediaEntryList> Lists { get; private set; }
    [JsonProperty("hasNextChunk")] public bool HasNextChunk { get; private set; }

}