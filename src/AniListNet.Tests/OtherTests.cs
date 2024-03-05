using AniListNet.Objects;
using AniListNet.Parameters;
using NUnit.Framework;

namespace AniListNet.Tests;

public class OtherTests
{
    private readonly AniClient _client = new();

    [Test]
    public async Task GetCharacterMediaTest()
    {
        var data = await _client.GetCharacterMediaAsync(1, new GetMediaFilter
        {
            Type = MediaType.Anime,
            Sort = MediaSort.Favorites
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetStaffProductionMediaTest()
    {
        var data = await _client.GetStaffProductionMediaAsync(95269);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetStaffVoicedMediaTest()
    {
        var data = await _client.GetStaffVoicedMediaAsync(95269);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetStaffVoicedCharactersTest()
    {
        var data = await _client.GetStaffVoicedCharactersAsync(95269);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }

    [Test]
    public async Task GetStudioMediaTest()
    {
        var data = await _client.GetStudioMediaAsync(1);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass(); // TODO: Add proper assertions
    }
}