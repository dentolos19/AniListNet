using NUnit.Framework;

namespace AniListNet.Tests;

public class GetTests
{

    private readonly AniClient _client = new();

    [Test]
    [TestCase(1)]
    public async Task GetMediaTest(int id)
    {
        var data = await _client.GetMediaAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(21)]
    public async Task GetMediaRelationsTest(int id)
    {
        var data = await _client.GetMediaRelationsAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaCharactersTest(int id)
    {
        var data = await _client.GetMediaCharactersAsync(id, new AniPaginationOptions(2, 5));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaStaffTest(int id)
    {
        var data = await _client.GetMediaStaffAsync(id, new AniPaginationOptions(2, 5));
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaStudiosTest(int id)
    {
        var data = await _client.GetMediaStudiosAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetCharacterTest(int id)
    {
        var data = await _client.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(95269)]
    public async Task GetStaffTest(int id)
    {
        var data = await _client.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

}