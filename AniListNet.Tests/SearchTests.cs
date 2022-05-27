using AniListNet.Models;
using AniListNet.Objects;
using NUnit.Framework;

namespace AniListNet.Tests;

public class SearchTests
{

    [Test]
    [TestCase("demon slayer")]
    public async Task SearchAnimeMediaTest(string query)
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new MediaFilter
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
        var results = await TestObjects.AniClient.SearchMediaAsync(new MediaFilter
        {
            Query = query,
            Sort = MediaSort.Popularity,
            Type = MediaType.Manga
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Manga));
    }

    [Test]
    public async Task SearchMediaBySeasonTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new MediaFilter
        {
            Season = MediaSeason.Winter
        });
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Season == MediaSeason.Winter));
    }

    [Test]
    public async Task SearchMediaByGenreTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new MediaFilter
        {
            Genres = new[] { "Action", "Fantasy" }
        });
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Genres.Contains("Action") && item.Genres.Contains("Fantasy")));
    }

    [Test]
    [TestCase("kazuha")]
    public async Task SearchCharacterTest(string query)
    {
        var results = await TestObjects.AniClient.SearchCharacterAsync(query, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    [TestCase("kazuha")]
    public async Task SearchStaffTest(string query)
    {
        var results = await TestObjects.AniClient.SearchStaffAsync(query, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    [TestCase("a")]
    public async Task SearchStudioTest(string query)
    {
        var results = await TestObjects.AniClient.SearchStudioAsync(query, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    [TestCase("kazuha")]
    public async Task SearchUserTest(string query)
    {
        var results = await TestObjects.AniClient.SearchUserAsync(query, new AniPaginationOptions(3, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

}