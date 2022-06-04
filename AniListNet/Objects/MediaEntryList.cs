using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntryList
{

    [JsonProperty("entries")] public MediaEntry[] Entries { get; private init; }
    [JsonProperty("name")] public string Name { get; private init; }
    [JsonProperty("isCustomList")] public bool IsCustomList { get; private init; }
    [JsonProperty("status")] public MediaEntryStatus Status { get; private init; }

}