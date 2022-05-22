using NUnit.Framework;

namespace AniListNet.Tests;

public class GetTests
{

    private readonly AniClient _client = new();

    [Test]
    public async Task GetGenreCollectionTest()
    {
        var data = await _client.GetGenreCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetTagCollectionTest()
    {
        var data = await _client.GetTagCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaTest(int id)
    {
        var data = await _client.GetMediaAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaSchedulesTest()
    {
        var data = await _client.GetMediaSchedulesAsync(new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetCharacterTest(int id)
    {
        var data = await _client.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(95269)]
    public async Task GetStaffTest(int id)
    {
        var data = await _client.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

    [Test]
    [TestCase(5741649)]
    public async Task GetUserTest(int id)
    {
        var data = await _client.GetUserAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(data.Id == id);
    }

}