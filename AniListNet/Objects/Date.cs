using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Date
{

    [JsonProperty("year")] public int? Year { get; private init; }
    [JsonProperty("month")] public int? Month { get; private init; }
    [JsonProperty("day")] public int? Day { get; private init; }

}