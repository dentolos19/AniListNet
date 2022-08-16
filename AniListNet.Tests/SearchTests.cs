using AniListNet.Objects;
using AniListNet.Parameters;
using NUnit.Framework;

namespace AniListNet.Tests;

public class SearchTests
{

    [Test]
    public async Task SearchAnimeMediaTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new SearchMediaFilter
        {
            Query = "demon slayer",
            Sort = MediaSort.Popularity,
            Type = MediaType.Anime
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Anime));
    }

    [Test]
    public async Task SearchMediaFormatTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new SearchMediaFilter
        {
            Query = "demon slayer",
            Sort = MediaSort.Popularity,
            Type = MediaType.Anime,
            Format = new Dictionary<MediaFormat, bool>{
                {MediaFormat.TV, true},
                {MediaFormat.TVShort, true},
                {MediaFormat.Special, true},
            }
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Anime));
    }

    [Test]
    public async Task SearchMangaMediaTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new SearchMediaFilter
        {
            Query = "one piece",
            Sort = MediaSort.Popularity,
            Type = MediaType.Manga
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Manga));
    }

    [Test]
    public async Task SearchMediaBySeasonTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new SearchMediaFilter
        {
            Season = MediaSeason.Winter
        });
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Season == MediaSeason.Winter));
    }

    [Test]
    public async Task SearchMediaByGenreTest()
    {
        var results = await TestObjects.AniClient.SearchMediaAsync(new SearchMediaFilter
        {
            Genres = new Dictionary<string, bool>
            {
                { "Action", true },
                { "Fantasy", true },
                { "Romance", false }
            }
        });
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item =>
            item.Genres.Contains("Action") &&
            item.Genres.Contains("Fantasy") &&
            !item.Genres.Contains("Romance")
        ));
    }

    [Test]
    public async Task SearchCharacterTest()
    {
        var results = await TestObjects.AniClient.SearchCharacterAsync("kazuha", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    public async Task SearchStaffTest()
    {
        var results = await TestObjects.AniClient.SearchStaffAsync("kazuha", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    public async Task SearchStudioTest()
    {
        var results = await TestObjects.AniClient.SearchStudioAsync("a", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    public async Task SearchUserTest()
    {
        var results = await TestObjects.AniClient.SearchUserAsync("dentolos", new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

}