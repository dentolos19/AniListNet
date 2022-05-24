using NUnit.Framework;

namespace AniListNet.Tests;

public class MediaTests
{

    [Test]
    [TestCase(21)]
    public async Task GetMediaRelationsTest(int id)
    {
        var data = await TestObjects.AniClient.GetMediaRelationsAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaCharactersTest(int id)
    {
        var data = await TestObjects.AniClient.GetMediaCharactersAsync(id, new AniPaginationOptions(2, 5));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaStaffTest(int id)
    {
        var data = await TestObjects.AniClient.GetMediaStaffAsync(id, new AniPaginationOptions(2, 5));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaStudiosTest(int id)
    {
        var data = await TestObjects.AniClient.GetMediaStudiosAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

}