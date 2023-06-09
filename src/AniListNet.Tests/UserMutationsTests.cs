using AniListNet.Objects;
using AniListNet.Parameters;
using DotNetEnv;
using NUnit.Framework;

namespace AniListNet.Tests;

public class UserMutationsTests
{
    [OneTimeSetUp]
    public async Task AuthorizationSetup()
    {
        // Load the AniListToken from .env file
        Directory.SetCurrentDirectory(Path.Join(Directory.GetCurrentDirectory(), "../../../"));
        Env.Load();

        var userToken = Environment.GetEnvironmentVariable("AniListToken");
        _ = await TestObjects.AniClient.TryAuthenticateAsync(userToken!);
    }

    [Test]
    public async Task UpdateUserOptionsTest() // TODO: needs more mutations
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var user = await TestObjects.AniClient.GetAuthenticatedUserAsync();
        var displayAdultContent = !user.Options.DisplayAdultContent;
        user = await TestObjects.AniClient.UpdateUserOptionsAsync(new UserOptionsMutation
        {
            DisplayAdultContent = displayAdultContent
        });
        Assert.IsTrue(
            user.Options.DisplayAdultContent == displayAdultContent
        );
    }

    [Test]
    public async Task SaveMediaEntryTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var status = MediaEntryStatus.Current;
        var progress = TestObjects.Random.Next(100);
        var startDate = DateTime.Today;
        var data = await TestObjects.AniClient.SaveMediaEntryAsync(1, new MediaEntryMutation
        {
            Status = MediaEntryStatus.Current,
            Progress = progress,
            StartDate = startDate
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(
            data.Status == status &&
            data.Progress == progress &&
            data.StartDate.ToDateTime() == startDate
        );
    }

    [Test]
    public async Task DeleteMediaEntryTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var mediaEntry = await TestObjects.AniClient.SaveMediaEntryAsync(1, new MediaEntryMutation { Progress = TestObjects.Random.Next(100) });
        var isDeleted = await TestObjects.AniClient.DeleteMediaEntryAsync(mediaEntry.Id);
        Assert.IsTrue(isDeleted);
    }

    [Test]
    public async Task ToggleFollowUserAsync()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized");
        var user = await TestObjects.AniClient.GetUserAsync(5114158);
        var userFollowed = await TestObjects.AniClient.ToggleFollowUserAsync(user.Id);
        Assert.AreEqual(!user.IsFollowing, userFollowed);
    }

    [Test]
    public async Task ToggleMediaFavoriteTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var media = await TestObjects.AniClient.GetMediaAsync(1);
        var mediaFavorite = await TestObjects.AniClient.ToggleMediaFavoriteAsync(media.Id, media.Type);
        Assert.AreEqual(!media.IsFavorite, mediaFavorite);
    }

    [Test]
    public async Task ToggleCharacterFavoriteTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var character = await TestObjects.AniClient.GetCharacterAsync(1);
        var characterFavorite = await TestObjects.AniClient.ToggleCharacterFavoriteAsync(character.Id);
        Assert.AreEqual(!character.IsFavorite, characterFavorite);
    }

    [Test]
    public async Task ToggleStaffFavoriteTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var staff = await TestObjects.AniClient.GetStaffAsync(95269);
        var staffFavorite = await TestObjects.AniClient.ToggleStaffFavoriteAsync(staff.Id);
        Assert.AreEqual(!staff.IsFavorite, staffFavorite);
    }

    [Test]
    public async Task ToggleStudioFavoriteTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var studio = await TestObjects.AniClient.GetStudioAsync(1);
        var studioFavorite = await TestObjects.AniClient.ToggleStudioFavoriteAsync(studio.Id);
        Assert.AreEqual(!studio.IsFavorite, studioFavorite);
    }
    
    [Test]
    public async Task SaveMediaReviewTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var body = TestObjects.RandomString(2200);
        var summary = TestObjects.RandomString(20);
        var data = await TestObjects.AniClient.SaveMediaReviewAsync(1, new MediaReviewMutation()
        {
            Body = body,
            Score = 1,
            IsPrivate = true,
            Summary = summary,
            MediaId = 1,
        });
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.IsTrue(
            data.Body == body &&
            data.Score == 1 &&
            data.Summary == summary &&
            data.IsPrivate
        );
    }

    [Test]
    public async Task DeleteMediaReviewAsyncTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var body = TestObjects.RandomString(2200);
        var summary = TestObjects.RandomString(20);
        var data = await TestObjects.AniClient.SaveMediaReviewAsync(1, new MediaReviewMutation()
        {
            Body = body,
            Score = 1,
            IsPrivate = true,
            Summary = summary,
            MediaId = 2,
        });

        Assert.True(await TestObjects.AniClient.DeleteMediaReviewAsync(data.Id));
    }
    
    [Test]
    public async Task RateMediaReviewAsyncTest()
    {
        if (!TestObjects.AniClient.IsAuthenticated)
            Assert.Fail("Client is not authorized.");
        var body = TestObjects.RandomString(2200);
        var summary = TestObjects.RandomString(20);
        var data = await TestObjects.AniClient.SaveMediaReviewAsync(1, new MediaReviewMutation()
        {
            Body = body,
            Score = 1,
            IsPrivate = true,
            Summary = summary,
            MediaId = 2,
        });
        
        // Rate the review
        var newData = await TestObjects.AniClient.RateMediaReviewAsync(data.Id, MediaReviewRating.DownVote);
        Assert.AreEqual(MediaReviewRating.DownVote, newData.UserRating);

        Assert.True(await TestObjects.AniClient.DeleteMediaReviewAsync(data.Id));
    }
}