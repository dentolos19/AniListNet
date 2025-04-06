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

    [Test]
    public async Task ValidateRateLimitTest()
    {
        int? retryAfter = null;
        int rateRemaining = 0;
        int rateLimit = 0;
        DateTime? rateReset = null;

        _client.RateChanged += (_, args) =>
        {
            retryAfter = args.RetryAfter;
            rateRemaining = args.RateRemaining;
            rateLimit = args.RateLimit;
            rateReset = args.RateReset;
        };

        _ = await _client.GetStudioMediaAsync(1);

        Console.WriteLine("Retry After: {0}", retryAfter.HasValue ? retryAfter.Value : "Null");
        Console.WriteLine("Rate Remaining: {0}", rateRemaining);
        Console.WriteLine("Rate Limit: {0}", rateLimit);
        Console.WriteLine("Rate Reset: {0}", rateReset.HasValue ? rateReset.Value : "Null");

        Assert.Multiple(() =>
        {
            Assert.That(rateLimit, Is.GreaterThan(0));
            Assert.That(rateRemaining, Is.EqualTo(rateLimit - 1));
        });
    }
}