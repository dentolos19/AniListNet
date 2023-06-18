using AniListNet.Helpers;

namespace AniListNet.Objects;

public class Date
{
    [GqlSelection("year")] public int? Year { get; private set; }
    [GqlSelection("month")] public int? Month { get; private set; }
    [GqlSelection("day")] public int? Day { get; private set; }

    public DateTime? ToDateTime()
    {
        if (Year.HasValue && Month.HasValue && Day.HasValue)
            return new DateTime(Year.Value, Month.Value, Day.Value);
        return null;
    }
}