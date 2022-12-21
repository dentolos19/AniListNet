using Newtonsoft.Json;

namespace AniListNet.Objects;

public class MediaEntryList
{

    [JsonProperty("entries")] public MediaEntry[] Entries { get; private set; }
    [JsonProperty("name")] public string Name { get; private set; }
    [JsonProperty("isCustomList")] public bool IsCustomList { get; private set; }
    [JsonProperty("isSplitCompletedList")] public bool IsSplitCompletedList { get; private set; }
    [JsonProperty("status")] public MediaEntryStatus? Status { get; private set; }

}