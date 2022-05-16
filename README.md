# AniList.NET

A simple .NET API wrapper for [AniList](https://anilist.co)!

> **Fact**: This was a side project of [Otakulore](https://github.com/dentolos19/Otakulore), now it's a fully-fledged project!

```cs
using AniListNet;

var client = new AniClient();

var results = await client.SearchMediaAsync(
    "one piece", // search term
    new AniPaginationOptions(2, 5) // set pagination to page 2 with 5 items
    );

Console.WriteLine("Search term: one piece");
foreach (var item in results.Data) // prints results info
    Console.WriteLine($"  {item.Type}: {item.Title.PreferredTitle} ({item.Format})");

var relations = await client.GetMediaRelationsAsync(1); // gets related media of id 1

Console.WriteLine($"Related media: ({relations.Length})");
foreach (var relatedItem in relations) // prints related media info
    Console.WriteLine($"  {relatedItem.Media.Type}: {relatedItem.Media.Title.PreferredTitle} ({relatedItem.Relation})");
```

## Features (Currently work-in-progress!)

- [X] Enables searching for media, characters, staff & more
- [X] Enables fetching relations for specific media
- [X] Enables fetching info for individual media, character, staff, etc.
- [ ] Allows for fetching airing schedules (from AniChart)
- [ ] Supports user mutution
  - [ ] Updating user settings
  - [ ] Updating user lists
- [X] Supports implicit grant authentication
- more features to be added soon!