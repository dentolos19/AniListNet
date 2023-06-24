using AniListNet.Objects;
using AniListNet.Parameters;
using DotNetEnv;
using NUnit.Framework;

namespace AniListNet.Tests;

public class UserMutationsTests
{
    private readonly AniClient _client = new();
    private readonly Random _random = new();

    private string GenerateRandomString(int length = 16, string additionalCharacters = "")
    {
        var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + additionalCharacters;
        return new string(Enumerable.Repeat(characters, length).Select(@string => @string[_random.Next(@string.Length)]).ToArray());
    }

    private TEnum GetRandomEnum<TEnum>()
    {
        var values = Enum.GetValues(typeof(TEnum));
        return (TEnum)values.GetValue(_random.Next(values.Length));
    }

    [OneTimeSetUp]
    public async Task AuthorizationSetup()
    {
        Env.Load(); // loads variables from .env file
        var userToken = Environment.GetEnvironmentVariable("AUTH_TOKEN");
        var isAuthorized = await _client.TryAuthenticateAsync(userToken!);
        if (!isAuthorized)
            throw new Exception("Client is not authorized.");
    }

    [Test]
    public async Task GetAuthenticatedUserTest()
    {
        var data = await _client.GetAuthenticatedUserAsync();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task UpdateUserOptionsTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var user = await _client.GetAuthenticatedUserAsync();
        var userMutation = new UserOptionsMutation
        {
            MediaTitleLanguage = GetRandomEnum<UserMediaTitleLanguage>(),
            DisplayAdultContent = !user.Options.DisplayAdultContent,
            ScoreFormat = GetRandomEnum<UserScoreFormat>(),
            StaffNameLanguage = GetRandomEnum<UserStaffNameLanguage>()
        };
        user = await _client.UpdateUserOptionsAsync(userMutation);
        Console.WriteLine(user.Dump());
        Assert.Multiple(() =>
        {
            // Assert.That(user.Options.MediaTitleLanguage, Is.EqualTo(userMutation.MediaTitleLanguage)); // TODO: fix this
            Assert.That(user.Options.DisplayAdultContent, Is.EqualTo(userMutation.DisplayAdultContent));
            Assert.That(user.ListOptions.ScoreFormat, Is.EqualTo(userMutation.ScoreFormat));
            // Assert.That(user.Options.StaffNameLanguage, Is.EqualTo(userMutation.StaffNameLanguage)); // TODO: fix this
        });
    }

    [Test]
    public async Task SaveMediaEntryTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var status = MediaEntryStatus.Current;
        var progress = _random.Next(100);
        var startDate = DateTime.Today;
        var data = await _client.SaveMediaEntryAsync(1, new MediaEntryMutation
        {
            Status = MediaEntryStatus.Current,
            Progress = progress,
            StartDate = startDate
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(
            data.Status == status &&
            data.Progress == progress &&
            data.StartDate.ToDateTime() == startDate,
            Is.True
        );
    }

    [Test]
    public async Task DeleteMediaEntryTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var mediaEntry = await _client.SaveMediaEntryAsync(1, new MediaEntryMutation { Progress = _random.Next(100) });
        var isDeleted = await _client.DeleteMediaEntryAsync(mediaEntry.Id);
        Assert.That(isDeleted, Is.True);
    }

    [Test]
    public async Task SaveMediaReviewTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var body = GenerateRandomString(2200);
        var summary = GenerateRandomString(20);
        var data = await _client.SaveMediaReviewAsync(1, new MediaReviewMutation
        {
            Body = body,
            Summary = summary,
            Score = 3,
            IsPrivate = true
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(
            data.Body == body &&
            data.Summary == summary &&
            data is { Score: 3, IsPrivate: true },
            Is.True
        );
    }

    [Test]
    public async Task SaveMediaReviewWithNewLinesTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var body = GenerateRandomString(2200, "\n");
        var summary = GenerateRandomString(20);
        var data = await _client.SaveMediaReviewAsync(1, new MediaReviewMutation
        {
            Body = body,
            Summary = summary,
            Score = 3,
            IsPrivate = true
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.That(
            data.Body == body &&
            data.Summary == summary &&
            data is { Score: 3, IsPrivate: true },
            Is.True
        );
    }

    [Test]
    public async Task DeleteMediaReviewTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var body = GenerateRandomString(2200);
        var summary = GenerateRandomString(20);
        var data = await _client.SaveMediaReviewAsync(1, new MediaReviewMutation
        {
            Body = body,
            Summary = summary,
            Score = 3,
            IsPrivate = true
        });
        Assert.That(await _client.DeleteMediaReviewAsync(data.Id), Is.True);
    }

    [Test]
    public async Task RateMediaReviewAsyncTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var data = await _client.SaveMediaReviewAsync(1, new MediaReviewMutation
        {
            Body = GenerateRandomString(2200),
            Score = 1,
            IsPrivate = true,
            Summary = GenerateRandomString(20)
        });
        var newData = await _client.RateMediaReviewAsync(data.Id, MediaReviewRating.DownVote);
        Assert.Multiple(async () =>
        {
            Assert.That(newData.UserRating, Is.EqualTo(MediaReviewRating.DownVote));
            Assert.That(await _client.DeleteMediaReviewAsync(data.Id), Is.True);
        });
    }

    [Test]
    public async Task SaveMediaRecommendationAsyncTest()
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var data = await _client.SaveMediaRecommendationAsync(30013, new MediaRecommendationMutation
        {
            Rating = MediaRecommendationRating.RateUp,
            MediaRecommendationId = 30012
        });
        Assert.That(data.UserRating, Is.EqualTo(MediaRecommendationRating.RateUp));
        data = await _client.SaveMediaRecommendationAsync(30013, new MediaRecommendationMutation
        {
            Rating = MediaRecommendationRating.NoRating,
            MediaRecommendationId = 30012
        });
        Assert.That(data.UserRating, Is.EqualTo(MediaRecommendationRating.NoRating));
    }

    [Test]
    [TestCase(5114158)]
    public async Task ToggleFollowUserAsync(int userId)
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized");
        var user = await _client.GetUserAsync(userId);
        var userFollowed = await _client.ToggleFollowUserAsync(user.Id);
        Assert.That(userFollowed, Is.EqualTo(!user.IsFollowing));
    }

    [Test]
    [TestCase(1)]
    public async Task ToggleMediaFavoriteTest(int mediaId)
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var media = await _client.GetMediaAsync(mediaId);
        var mediaFavorite = await _client.ToggleMediaFavoriteAsync(media.Id, media.Type);
        Assert.That(mediaFavorite, Is.EqualTo(!media.IsFavorite));
    }

    [Test]
    [TestCase(1)]
    public async Task ToggleCharacterFavoriteTest(int characterId)
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var character = await _client.GetCharacterAsync(characterId);
        var characterFavorite = await _client.ToggleCharacterFavoriteAsync(character.Id);
        Assert.That(characterFavorite, Is.EqualTo(!character.IsFavorite));
    }

    [Test]
    [TestCase(95269)]
    public async Task ToggleStaffFavoriteTest(int staffId)
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var staff = await _client.GetStaffAsync(staffId);
        var staffFavorite = await _client.ToggleStaffFavoriteAsync(staff.Id);
        Assert.That(staffFavorite, Is.EqualTo(!staff.IsFavorite));
    }

    [Test]
    [TestCase(1)]
    public async Task ToggleStudioFavoriteTest(int studioId)
    {
        if (!_client.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var studio = await _client.GetStudioAsync(studioId);
        var studioFavorite = await _client.ToggleStudioFavoriteAsync(studio.Id);
        Assert.That(studioFavorite, Is.EqualTo(!studio.IsFavorite));
    }
}