using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Date
{

    [JsonProperty("year")] public int? Year { get; private set; }
    [JsonProperty("month")] public int? Month { get; private set; }
    [JsonProperty("day")] public int? Day { get; private set; }

    public DateTime? ToDateTime()
    {
        if (Year.HasValue && Month.HasValue && Day.HasValue)
            return new DateTime(Year.Value, Month.Value, Day.Value);
        return null;
    }

}