using Newtonsoft.Json;

namespace AniListNet.Objects;

/// <summary>
/// List group of anime or manga entries.
/// </summary>
public class MediaList
{
    [JsonProperty("name")] public string Name { get; private set; }
    [JsonProperty("isCustomList")] public string IsCustom { get; private set; }
    [JsonProperty("status")] public MediaEntryStatus? Status { get; private set; }
}