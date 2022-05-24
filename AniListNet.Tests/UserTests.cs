using NUnit.Framework;

namespace AniListNet.Tests;

public class UserTests
{

    [Test]
    public async Task GetUserFollowersTest()
    {
        var data = await TestObjects.AniClient.GetUserFollowersAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserFollowingsTest()
    {
        var data = await TestObjects.AniClient.GetUserFollowingsAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserEntriesTest()
    {
        var data = await TestObjects.AniClient.GetUserEntriesAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

}