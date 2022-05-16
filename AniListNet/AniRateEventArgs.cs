namespace AniListNet;

public class AniRateEventArgs : EventArgs
{

    public int RateLimit { get; }
    public int RateRemaining { get; }

    public AniRateEventArgs(int rateLimit, int rateRemaining)
    {
        RateLimit = rateLimit;
        RateRemaining = rateRemaining;
    }

}