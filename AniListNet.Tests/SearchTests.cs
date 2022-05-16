using AniListNet.Objects;
using NUnit.Framework;

namespace AniListNet.Tests;

public class SearchTests
{

    private readonly AniClient _client = new();

    [Test]
    [TestCase("demon slayer")]
    public async Task SearchAnimeMediaTest(string query)
    {
        var results = await _client.SearchMediaAsync(new AniFilter
        {
            Query = query,
            Sort = MediaSort.Popularity,
            Type = MediaType.Anime
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Anime));
    }

    [Test]
    [TestCase("one piece")]
    public async Task SearchMangaMediaTest(string query)
    {
        var results = await _client.SearchMediaAsync(new AniFilter
        {
            Query = query,
            Sort = MediaSort.Popularity,
            Type = MediaType.Manga
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Manga));
    }

    [Test]
    [TestCase("kazuha")]
    public async Task SearchCharacterTest(string query)
    {
        var results = await _client.SearchCharacterAsync(query, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    [TestCase("kazuha")]
    public async Task SearchStaffTest(string query)
    {
        var results = await _client.SearchStaffAsync(query, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    [TestCase("a")]
    public async Task SearchStudioTest(string query)
    {
        var results = await _client.SearchStudioAsync(query, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

}