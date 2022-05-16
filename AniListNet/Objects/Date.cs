using Newtonsoft.Json;

namespace AniListNet.Objects;

public class Date
{

    [JsonProperty("year")] public int? Year { get; private init; }
    [JsonProperty("month")] public int? Month { get; private init; }
    [JsonProperty("day")] public int? Day { get; private init; }

    public DateOnly? ToDateOnly()
    {
        if (Year.HasValue && Month.HasValue && Day.HasValue)
            return new DateOnly(Year.Value, Month.Value, Day.Value);
        if (Year.HasValue)
            return new DateOnly(Year.Value, 0, 0);
        return null;
    }

}