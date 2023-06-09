using AniListNet.Parameters;
using NUnit.Framework;

namespace AniListNet.Tests;

public class GetTests
{
    [Test]
    public async Task GetGenreCollectionTest()
    {
        var data = await TestObjects.AniClient.GetGenreCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetTagCollectionTest()
    {
        var data = await TestObjects.AniClient.GetTagCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaTest()
    {
        var id = 1;
        var data = await TestObjects.AniClient.GetMediaAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.AreEqual(id, data.Id);
    }

    [Test]
    public async Task GetMediaSchedulesTest()
    {
        var data = await TestObjects.AniClient.GetMediaSchedulesAsync(new MediaSchedulesFilter
        {
            StartedAfterDate = DateTime.Now,
            EndedBeforeDate = DateTime.Now.AddMonths(1)
        }, new AniPaginationOptions(2, 100));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetTrendingMediaAsyncTest()
    {
        var data = await TestObjects.AniClient.GetTrendingMediaAsync(new MediaTrendFilter(),
            new AniPaginationOptions(2, 100));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetCharacterTest()
    {
        var id = 1;
        var data = await TestObjects.AniClient.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.AreEqual(id, data.Id);
    }

    [Test]
    public async Task GetMediaReviewAsyncTest()
    {
        var id = 4148;
        var data = await TestObjects.AniClient.GetMediaReviewAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.AreEqual(id, data.Id);
    }

    [Test]
    public async Task GetStaffTest()
    {
        var id = 95269;
        var data = await TestObjects.AniClient.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.AreEqual(id, data.Id);
    }

    [Test]
    public async Task GetStudioTest()
    {
        var id = 1;
        var data = await TestObjects.AniClient.GetStudioAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.AreEqual(id, data.Id);
    }

    [Test]
    public async Task GetUserTest()
    {
        var id = 5114158;
        var data = await TestObjects.AniClient.GetUserAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.AreEqual(id, data.Id);
    }
}