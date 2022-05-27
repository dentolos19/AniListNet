namespace AniListNet.Tests;

public static class TestObjects
{

    private static Random? _random;
    private static AniClient? _aniClient;

    public static Random Random => _random ??= new Random();
    public static AniClient AniClient => _aniClient ??= new AniClient();

}