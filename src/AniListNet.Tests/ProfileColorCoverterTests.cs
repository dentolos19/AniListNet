using System.Collections;
using AniListNet.Helpers;
using AniListNet.Objects;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AniListNet.Tests;

[TestFixture]
public class ProfileColorConverterTests
{
    private JsonSerializerSettings _serializerSettings;
    

    [SetUp]
    public void SetUp()
    {
        _serializerSettings = new JsonSerializerSettings
        {
            Converters = { new ProfileColorConverter() }
        };
    }

    public static IEnumerable TestCases()
    {
        yield return new TestCaseData("{ \"profileColor\": \"blue\" }", UserProfileColor.Blue);
        yield return new TestCaseData("{ \"profileColor\": \"yellow\" }", UserProfileColor.Custom);
        yield return new TestCaseData("{ \"profileColor\": null }", UserProfileColor.Custom);
        yield return new TestCaseData("{ \"profileColor\": \"#ff0000\" }", UserProfileColor.Custom);
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Deserialize_ReturnsExpectedEnumValue(string json, UserProfileColor? expectedColor)
    {
        var example = JsonConvert.DeserializeObject<UserOptions>(json, _serializerSettings);
        Assert.AreEqual(expectedColor, example?.ProfileColor);
    }
}