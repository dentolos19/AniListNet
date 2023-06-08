using AniListNet.Objects;
using AniListNet.Parameters;
using NUnit.Framework;

namespace AniListNet.Tests;

public class UserMutationsTests
{
    [OneTimeSetUp]
    public async Task AuthorizationSetup()
    {
        _ = await TestObjects.AniClient.TryAuthenticateAsync("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6ImViNDhjMGRiZTUwN2ZjZWZhZjVhZDEyMjg1OTBhZDBhNGQ2ODEwM2MyMmE5OGUxMjZjOTgwMmNkZGQyNTBmMzEyYWMwZjY2NGFlMjMzYTgyIn0.eyJhdWQiOiIxMjgwOSIsImp0aSI6ImViNDhjMGRiZTUwN2ZjZWZhZjVhZDEyMjg1OTBhZDBhNGQ2ODEwM2MyMmE5OGUxMjZjOTgwMmNkZGQyNTBmMzEyYWMwZjY2NGFlMjMzYTgyIiwiaWF0IjoxNjg1NDc1NTA5LCJuYmYiOjE2ODU0NzU1MDksImV4cCI6MTcxNzA5NzkwOSwic3ViIjoiNjI5MzU3NiIsInNjb3BlcyI6W119.ubHr0nE-N25EwnBEuCOgb5YLJVf03ErZKK5wBWS52VBROHiT33JTuoJ4NiREYFqXuVNeG5IaBq6wdoHT9Avk6NU631hNiLiA2OLKF6n2U1KI5p3fEMkiSKIbek8ERA9r6qhi93LlYZo_xBIQhIuaRjVIqQDdbYMEc6zzhBUx46DRB_fCilSy_e5n-nEy3osaG1VDfW6HV9tna9iholjkyj5YBsgzf9fQXYS2x-i_1DAIdrLCk7_5OrkJE0CoORdQYu95XWQv08dzEvcC5b8iNERlJdSFn5U9PspzPafNruhRyooGcuEE9MWgssACH02Q--PDMQJmPTLpc_QMBsf0pZLxdYR6ca6MFp2b3NmYxxl40ncvzbE16WuUstoqLJuG5h3dEC5OrWPEyOjhtiZiSu4TSV7m9cbAYXTSkwYOX1o4WrRLBQN4RQ5WQypS5BwLg0-709MzxPhatsr2QY-7dotVv3v2C_qfrraJHIltSgopEsMP-GXkzy9Pv6ZT3mKHg7Knfx-vCritT4JoZKIC3HDb0d8NmIg-Aq4pCJ_oWNV0XCuNBIrAJnsRMvl5jlbFcEUkyzZKBPtFat7C76CtaZ30kGxio8d1fdruZ-eavwsKj343FTBD6vlq19X7OD90OjAqP52GqBilAQwXaoKK73GwMljteRyPLzvWQSsvyo4");
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
        var body = new string(Enumerable
            .Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 2200)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
        var summary = new string(Enumerable
            .Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 20)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
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
}