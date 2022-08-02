using Newtonsoft.Json;

namespace AniListNet.Objects.Internal;

internal class MediaEntrySubMedia
{

    [JsonProperty("episodes")] public int? Episodes { get; private set; }
    [JsonProperty("chapters")] public int? Chapters { get; private set; }
    [JsonProperty("volumes")] public int? Volumes { get; private set; }

}