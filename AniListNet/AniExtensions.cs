using AniListNet.Objects;

namespace AniListNet;

public static class AniExtensions
{

    public static DateOnly? ToDateOnly(this Date date)
    {
        if (date.Year.HasValue && date.Month.HasValue && date.Day.HasValue)
            return new DateOnly(date.Year.Value, date.Month.Value, date.Day.Value);
        return null;
    }

}