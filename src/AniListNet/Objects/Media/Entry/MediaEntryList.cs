using AniListNet.Helpers;

namespace AniListNet.Objects;

public class MediaEntryList
{
    [GqlSelection("entries")] public MediaEntry[] Entries { get; private set; }
    [GqlSelection("name")] public string Name { get; private set; }
    [GqlSelection("isCustomList")] public bool IsCustomList { get; private set; }
    [GqlSelection("isSplitCompletedList")] public bool IsSplitCompletedList { get; private set; }
    [GqlSelection("status")] public MediaEntryStatus? Status { get; private set; }
}