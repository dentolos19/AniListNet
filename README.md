# <img src=".github/icon.png" width="32"/> AniList.NET [![](https://img.shields.io/nuget/v/AniListNet?label=NuGet&logo=nuget&style=flat-square)](https://www.nuget.org/packages/AniListNet)

[![](https://img.shields.io/badge/Powered%20By-.NET-blue?logo=microsoft&style=flat-square)](https://dotnet.microsoft.com)
[![](https://img.shields.io/badge/Made%20With-Visual%20Studio-blue?logo=visual-studio&style=flat-square)](https://visualstudio.microsoft.com)

A simple .NET API wrapper for [AniList](https://anilist.co)!

> **Fact**: This was a side project of [Otakulore](https://github.com/dentolos19/Otakulore), now it's a fully-fledged project!

```cs
using AniListNet;

var client = new AniClient();

Console.WriteLine("Search results for \"one piece\"");
var results = await client.SearchMediaAsync("one piece"); // searches for the term
foreach (var item in results.Data)
    Console.WriteLine($"  {item.Format}: {item.Title.PreferredTitle}");
Console.WriteLine();

var firstResult = results.Data.First();
Console.WriteLine($"Characters of the first result: {firstResult.Title.PreferredTitle} ({firstResult.Format})");
var characters = await client.GetMediaCharactersAsync(firstResult.Id); // gets character list of the first result
foreach (var character in characters.Data)
    Console.WriteLine($"  {character.Role}: {character.Character.Name.FullName}");
```

## Features

- [X] Has search query functions
  - [X] `SearchMediaAsync`: searches for Anime & Manga (supports filtering)
  - [X] `SearchCharacterAsync`
  - [X] `SearchStaffAsync`
  - [X] `SearchStudioAsync`
  - [X] `SearchUserAsync`
- [X] Has data query functions
  - [X] `GetGenreCollection`: gets all supported genres (e.g. Action, Fantasy, Romance)
  - [X] `GetTagCollection`: gets all supported tags (e.g. Male Protagonist, Heterosexual, Cultivation)
  - [X] `GetMediaAsync`
  - [X] `GetMediaSchedulesAsync`
  - [X] `GetCharacterAsync`
  - [X] `GetStaffAsync`
  - [X] `GetStudioAsync`
  - [X] `GetUserAsync`
- [ ] Has user-only mutation functions (TODO)
  - [X] `TryAuthenticateAsync`: only supports implicit grant tokens
  - [X] `GetAuthenticatedUserAsync`
  - [ ] `SaveMediaEntryAsync`
  - [ ] `DeleteMediaEntryAsync`
- [X] Has media-specific data query functions
  - [X] `GetMediaRelationsAsync`
  - [X] `GetMediaCharactersAsync`
  - [X] `GetMediaStaffAsync`
  - [X] `GetMediaStudiosAsync`
- [ ] Has character-specific data query functions (TODO)
- [ ] Has staff-specific data query functions (TODO)
- [ ] Has studio-specific data query functions (TODO)
- [ ] Has user-specific data query functions (TODO)