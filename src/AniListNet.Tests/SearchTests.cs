using AniListNet.Objects;
using AniListNet.Parameters;
using NUnit.Framework;

namespace AniListNet.Tests;

public class SearchTests
{
    private readonly AniClient _client = new();

    [Test]
    public async Task SearchAnimeMediaTest()
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Query = "demon slayer",
            Sort = MediaSort.Popularity,
            Type = MediaType.Anime
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Anime));
    }

    [Test]
    public async Task SearchMangaMediaTest()
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Query = "one piece",
            Sort = MediaSort.Popularity,
            Type = MediaType.Manga
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Type == MediaType.Manga));
    }

    [Test]
    public async Task SearchMediaByFormatTest()
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Query = "demon slayer",
            Sort = MediaSort.Popularity,
            Type = MediaType.Anime,
            Format = new Dictionary<MediaFormat, bool>
            {
                { MediaFormat.TV, true },
                { MediaFormat.TVShort, true },
                { MediaFormat.Special, true },
                { MediaFormat.Movie, false }
            }
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Format is
            (MediaFormat.TV or
            MediaFormat.TVShort or
            MediaFormat.Special) and not
            MediaFormat.Movie
        ));
    }

    [Test]
    public async Task SearchMediaBySeasonTest()
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Season = MediaSeason.Winter
        });
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.IsTrue(results.Data.Any(item => item.Season == MediaSeason.Winter));
    }

    [Test]
    public async Task SearchMediaByGenreTest()
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
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
        var results = await _client.SearchCharacterAsync("kazuha", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    public async Task SearchStaffTest()
    {
        var results = await _client.SearchStaffAsync("kazuha", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    public async Task SearchStudioTest()
    {
        var results = await _client.SearchStudioAsync("a", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }

    [Test]
    public async Task SearchUserTest()
    {
        var results = await _client.SearchUserAsync("dentolos", new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass();
    }
}