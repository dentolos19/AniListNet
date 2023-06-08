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

    public static string RandomString(int length)
    {
        return new string(Enumerable
            .Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}