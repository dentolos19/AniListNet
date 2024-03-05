using AniListNet.Objects;
using AniListNet.Parameters;
using NUnit.Framework;

namespace AniListNet.Tests;

public class SearchTests
{
    private readonly AniClient _client = new();

    [Test]
    [TestCase("one piece")]
    [TestCase("demon slayer")]
    public async Task SearchAnimeMediaTest(string query)
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Query = query,
            Sort = MediaSort.Popularity,
            Type = MediaType.Anime
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.That(
            results.Data.Any(item => item.Type == MediaType.Anime),
            Is.True
        );
    }

    [Test]
    [TestCase("black clover")]
    [TestCase("oshi no ko")]
    public async Task SearchMangaMediaTest(string query)
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Query = query,
            Sort = MediaSort.Popularity,
            Type = MediaType.Manga
        }, new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.That(
            results.Data.Any(item => item.Type == MediaType.Manga),
            Is.True
        );
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
        Assert.That(
            results.Data.Any(item => item.Format is
                (MediaFormat.TV or
                MediaFormat.TVShort or
                MediaFormat.Special) and not
                MediaFormat.Movie
            ),
            Is.True
        );
    }

    [Test]
    public async Task SearchMediaBySeasonTest()
    {
        var results = await _client.SearchMediaAsync(new SearchMediaFilter
        {
            Season = MediaSeason.Winter
        });
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.That(
            results.Data.Any(item => item.Season == MediaSeason.Winter),
            Is.True
        );
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
        Assert.That(
            results.Data.Any(item =>
                item.Genres.Contains("Action") &&
                item.Genres.Contains("Fantasy") &&
                !item.Genres.Contains("Romance")
            ),
            Is.True
        );
    }

    [Test]
    public async Task SearchCharacterTest()
    {
        var results = await _client.SearchCharacterAsync("kazuha", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task SearchCharacterByBirthdayTest()
    {
        var results = await _client.SearchCharacterAsync(new SearchCharacterFilter
        {
            IsBirthday = true,
            Sort = CharacterSort.Favorites
        }, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task SearchStaffTest()
    {
        var results = await _client.SearchStaffAsync("kazuha", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task SearchStaffByBirthdayTest()
    {
        var results = await _client.SearchStaffAsync(new SearchStaffFilter
        {
            IsBirthday = true,
            Sort = StaffSort.Favorites
        }, new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task SearchStudioTest()
    {
        var results = await _client.SearchStudioAsync("a", new AniPaginationOptions(2, 10));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task SearchUserTest()
    {
        var results = await _client.SearchUserAsync("dentolos", new AniPaginationOptions(1, 5));
        Console.WriteLine(ObjectDumper.Dump(results));
        Assert.Pass(); // TODO: Add proper assertions
    }
}