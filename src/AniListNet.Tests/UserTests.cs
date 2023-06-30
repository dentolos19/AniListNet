using AniListNet.Objects;
using NUnit.Framework;

namespace AniListNet.Tests;

public class UserTests
{
    private readonly AniClient _client = new();

    [Test]
    public async Task GetUserFollowersTest()
    {
        var data = await _client.GetUserFollowersAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserFollowingsTest()
    {
        var data = await _client.GetUserFollowingsAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserEntriesTest()
    {
        var data = await _client.GetUserEntriesAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserEntryCollectionTest()
    {
        var data = await _client.GetUserEntryCollectionAsync(1, MediaType.Anime);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserListCollectionTest()
    {
        var data = await _client.GetUserListCollectionAsync(1, MediaType.Anime);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserAnimeFavoritesTest()
    {
        var data = await _client.GetUserAnimeFavoritesAsync(5114158);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserMangaFavoritesTest()
    {
        var data = await _client.GetUserMangaFavoritesAsync(5114158);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserMediaReviewsTest()
    {
        var data = await _client.GetUserMediaReviews(98098);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserCharactersFavoritesTest()
    {
        var data = await _client.GetUserCharacterFavoritesAsync(5114158);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserStaffFavoritesTest()
    {
        var data = await _client.GetUserStaffFavoritesAsync(5114158);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetUserStudiosFavoritesTest()
    {
        var data = await _client.GetUserStudioFavoritesAsync(5114158);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }
}