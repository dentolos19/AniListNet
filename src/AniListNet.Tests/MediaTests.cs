using NUnit.Framework;

namespace AniListNet.Tests;

public class MediaTests
{
    private readonly AniClient _client = new();

    [Test]
    [TestCase(1, "Space", "Crime")]
    public async Task GetMediaTagsAsync(int id, params string[] genres)
    {
        var data = await _client.GetMediaTagsAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(genres.All(genre => data.Any(tag => tag.Name == genre)), Is.True);
    }

    [Test]
    [TestCase(21, 466, 1094)]
    public async Task GetMediaRelationsTest(int id, params int[] relatedIds)
    {
        var data = await _client.GetMediaRelationsAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(relatedIds.All(relatedId => data.Any(media => media.Media.Id == relatedId)), Is.True);
    }

    [Test]
    public async Task GetMediaCharactersTest()
    {
        var data = await _client.GetMediaCharactersAsync(1, new AniPaginationOptions(2, 5));
        // var data = await (await _client.GetMediaAsync(1)).GetCharactersAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetMediaStaffTest()
    {
        var data = await _client.GetMediaStaffAsync(1, new AniPaginationOptions(2, 5));
        // var data = await (await _client.GetMediaAsync(1)).GetStaffAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetMediaStudiosTest()
    {
        var data = await _client.GetMediaStudiosAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    [TestCase(1)]
    [TestCase(98014)]
    public async Task GetMediaRecommendationsTest(int id)
    {
        var data = await _client.GetMediaRecommendationsAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetMediaReviewsTest()
    {
        var data = await _client.GetMediaReviewsAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    // TODO: Needs improvement
    [Test]
    public async Task GetMediaEntryTest()
    {
        var data = await _client.GetMediaEntryAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }
}