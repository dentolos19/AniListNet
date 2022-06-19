using AniListNet.Models;
using AniListNet.Objects;
using NUnit.Framework;

namespace AniListNet.Tests;

public class UserMutationsTests
{

    [OneTimeSetUp]
    public async Task AuthorizationSetup()
    {
        _ = await TestObjects.AniClient.TryAuthenticateAsync("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6Ijc1NGZmMDhkMjY4NWQ2N2ZjYzA0NTdiOTVhMzMwNDU2ZTc4NzIwNDJlMTFkNzdjMDg5MDQ0NDI1NGQ2YzBkNzA5YTdiZjdhYjU3MWQxMDUxIn0.eyJhdWQiOiI3Mzc1IiwianRpIjoiNzU0ZmYwOGQyNjg1ZDY3ZmNjMDQ1N2I5NWEzMzA0NTZlNzg3MjA0MmUxMWQ3N2MwODkwNDQ0MjU0ZDZjMGQ3MDlhN2JmN2FiNTcxZDEwNTEiLCJpYXQiOjE2NTMyMDQ3NzAsIm5iZiI6MTY1MzIwNDc3MCwiZXhwIjoxNjg0NzQwNzcwLCJzdWIiOiI1MTE0MTQ4Iiwic2NvcGVzIjpbXX0.H0HNwozkDXZARBWpK6tqxdB4mttVcIzSvAujVriJevr9Cw15CmU65v_JK-Qkba9rE_Arc2pPZrooC2hZJrEaMV98teZwTsmbf59lDNObJlcpjRlEsdDGSRxnhC--ZyOywRoOW9Syv0TJZFmXMUrHK3zOictOgS7tohm3y8XW7b-tdgU5ZBGc-mNhlXb2r_CPvW6_Y2_yDZXAab9aLAMgMhmaLrpDGp911m5A7Y6dESKNG18dO17R1iyoBEadKf2qyNq-zKqa3MgLkGhW7FcEM--c3JibsFuE00gE-u-1btgs5SSLzqrYaJ_08ELS7C-0pkUsGPebJk-s8wv_UxeNQoInWDwGrQF3jpYouzTueCwoxGHLhxmerD1ER9K3enlxK2xiq39YtOn1pRdDgOgTeX7xhy3xCZJShQofZ1Tk8Ye1Q_iJCnp5XWqyqSe-DLEQfZDGKNSsHaRofBuMnGftfDeeLfx2Hx9SxdZSRpsqvOu-mzVx9QStXGn6Ej6BE4gUnNp6Z8UEKkLCIXdiAh9EZejxLgze5ygRoYQZfW_DtF9F0iuqVE6t-5LDpiKHuENlYBMsApuJsO_JEj76clVcL_bXLvFnDrDfd2DbpoRilK1WfU1UX8s7vD-CK-KaKv1VVtyKKx-WdtSjro__XoDgPC4o69iGu-S_ISnarT_3Xyw");
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

}