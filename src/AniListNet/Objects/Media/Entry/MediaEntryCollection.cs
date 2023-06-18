using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaEntryCollection
{
    [GqlSelection("lists")] public MediaEntryList[] Lists { get; private set; }
    [GqlSelection("hasNextChunk")] public bool HasNextChunk { get; private set; }
}