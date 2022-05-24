namespace AniListNet.Tests;

public static class TestObjects
{

    private static AniClient? _aniClient;

    public static AniClient AniClient => _aniClient ??= new AniClient();

}