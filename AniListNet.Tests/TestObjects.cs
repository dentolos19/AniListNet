using System.Diagnostics;

namespace AniListNet.Tests;

public static class TestObjects
{
    private static Random? _random;
    private static AniClient? _aniClient;

    public static Random Random => _random ??= new Random();

    public static AniClient AniClient
    {
        get
        {
            if (_aniClient == null)
            {
                _aniClient = new AniClient();
                _aniClient.RateChanged += (_, args) => Debug.WriteLine($"Rate Gauge: {args.RateRemaining}/{args.RateLimit}");
            }
            return _aniClient;
        }
    }
}