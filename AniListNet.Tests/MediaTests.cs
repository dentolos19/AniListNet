using NUnit.Framework;

namespace AniListNet.Tests;

public class MediaTests
{

    [Test]
    public async Task GetMediaTagsAsync()
    {
        var data = await TestObjects.AniClient.GetMediaTagsAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaRelationsTest()
    {
        var data = await TestObjects.AniClient.GetMediaRelationsAsync(21);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaCharactersTest()
    {
        var data = await TestObjects.AniClient.GetMediaCharactersAsync(1, new AniPaginationOptions(2, 5));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaStaffTest()
    {
        var data = await TestObjects.AniClient.GetMediaStaffAsync(1, new AniPaginationOptions(2, 5));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaStudiosTest()
    {
        var data = await TestObjects.AniClient.GetMediaStudiosAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaEntryTest() // TODO: need improvement
    {
        var data = await TestObjects.AniClient.GetMediaEntryAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

}