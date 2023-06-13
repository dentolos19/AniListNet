using AniListNet.Parameters;
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
        Assert.That(data, Is.Not.Empty);
    }

    [Test]
    public async Task GetTagCollectionTest()
    {
        var data = await _client.GetTagCollectionAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data, Is.Not.Empty);
    }

    [Test]
    [TestCase(1)]
    public async Task GetMediaTest(int id)
    {
        var data = await _client.GetMediaAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Id, Is.EqualTo(id));
    }

    [Test]
    [TestCase(4148)]
    public async Task GetMediaReviewTest(int id)
    {
        var data = await _client.GetMediaReviewAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Id, Is.EqualTo(id));
    }

    [Test]
    public async Task GetMediaSchedulesTest()
    {
        var data = await _client.GetMediaSchedulesAsync(new MediaSchedulesFilter
        {
            StartedAfterDate = DateTime.Now,
            EndedBeforeDate = DateTime.Now.AddMonths(1)
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Data, Is.Not.Empty);
    }

    [Test]
    public async Task GetTrendingMediaTest()
    {
        var data = await _client.GetTrendingMediaAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Data, Is.Not.Empty);
    }

    [Test]
    [TestCase(1)]
    public async Task GetCharacterTest(int id)
    {
        var data = await _client.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Id, Is.EqualTo(id));
    }

    [Test]
    [TestCase(95269)]
    public async Task GetStaffTest(int id)
    {
        var data = await _client.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Id, Is.EqualTo(id));
    }

    [Test]
    [TestCase(1)]
    public async Task GetStudioTest(int id)
    {
        var data = await _client.GetStudioAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Id, Is.EqualTo(id));
    }

    [Test]
    [TestCase(5114158)]
    public async Task GetUserTest(int id)
    {
        var data = await _client.GetUserAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(data.Id, Is.EqualTo(id));
    }
}