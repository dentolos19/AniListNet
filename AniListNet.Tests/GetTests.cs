using NUnit.Framework;

namespace AniListNet.Tests;

public class GetTests
{

    [Test]
    public async Task GetGenreCollectionTest()
    {
        var data = await SingletonObjects.AniClient.GetGenreCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetTagCollectionTest()
    {
        var data = await SingletonObjects.AniClient.GetTagCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaTest(int id)
    {
        var data = await SingletonObjects.AniClient.GetMediaAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    public async Task GetMediaSchedulesTest()
    {
        var data = await SingletonObjects.AniClient.GetMediaSchedulesAsync(new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetCharacterTest(int id)
    {
        var data = await SingletonObjects.AniClient.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(95269)]
    public async Task GetStaffTest(int id)
    {
        var data = await SingletonObjects.AniClient.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(1)]
    public async Task GetStudioTest(int id)
    {
        var data = await SingletonObjects.AniClient.GetStudioAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(5741649)]
    public async Task GetUserTest(int id)
    {
        var data = await SingletonObjects.AniClient.GetUserAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

}