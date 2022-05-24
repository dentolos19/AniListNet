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
    [TestCase(1)]
    public async Task GetMediaTest(int id)
    {
        var data = await TestObjects.AniClient.GetMediaAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    public async Task GetMediaSchedulesTest()
    {
        var data = await TestObjects.AniClient.GetMediaSchedulesAsync(new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetCharacterTest(int id)
    {
        var data = await TestObjects.AniClient.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(95269)]
    public async Task GetStaffTest(int id)
    {
        var data = await TestObjects.AniClient.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(1)]
    public async Task GetStudioTest(int id)
    {
        var data = await TestObjects.AniClient.GetStudioAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(5741649)]
    public async Task GetUserTest(int id)
    {
        var data = await TestObjects.AniClient.GetUserAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

}