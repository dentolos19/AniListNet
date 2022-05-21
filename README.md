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

- [X] Has data search functions
  - [X] `SearchMediaAsync`
  - [X] `SearchCharacterAsync`
  - [X] `SearchStaffAsync`
  - [X] `SearchStudioAsync`
  - [X] `SearchUserAsync`
- [X] Has data get functions
  - [X] `GetGenreCollection`
  - [X] `GetTagCollection`
  - [X] `GetMediaAsync`
  - [ ] `GetMediaSchedulesAsync`
  - [X] `GetCharacterAsync`
  - [X] `GetStaffAsync`
  - [ ] `GetStudioAsync`
  - [X] `GetUserAsync`
- [X] Has user mutation functions
  - [ ] `GetAuthenticatedUserAsync`
  - [ ] `SaveMediaEntryAsync`
  - [ ] `DeleteMediaEntryAsync`
- [X] Has media-specific data get functions
  - [X] `GetMediaRelationsAsync`
  - [X] `GetMediaCharactersAsync`
  - [X] `GetMediaStaffAsync`
  - [X] `GetMediaStudiosAsync`
- [X] Has character-specific data get functions (TODO)
- [X] Has staff-specific data get functions (TODO)
- [X] Has studio-specific data get functions (TODO)
- [X] Has user-specific data get functions (TODO)