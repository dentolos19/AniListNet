# <img src=".github/icon.png" width="48px"/> AniList.NET [![](https://img.shields.io/nuget/v/AniListNet?label=NuGet&logo=nuget&style=flat-square)](https://nuget.org/packages/AniListNet)

A simple .NET API wrapper for [AniList](https://anilist.co)!

This project is designed to bring you a simpler way to access and interact with the AniList API. For more information about the API itself, visit [AniList APIv2 docs](https://anilist.gitbook.io/anilist-apiv2-docs).

> **Note**: This was formerly a side project of [Otakulore](https://github.com/dentolos19/Otakulore), now it's a fully-fledged project!

## ⚒️ Usage

Install the library in your project.

- .NET CLI: `dotnet add package AniListNet`
- Package Manager CLI: `Install-Package AniListNet`

```cs
using AniListNet;
using AniListNet.Objects;
using AniListNet.Parameters;

// simple class that fulfils all your needs
var client = new AniClient();

// simple authentication with AniList
await client.TryAuthenticateAsync("<AUTH_TOKEN>");

var results = await client.SearchMediaAsync(new SearchMediaFilter
{
   Query = "one piece",
   Type = MediaType.Anime,
   Sort = MediaSort.Popularity,
   Format = new Dictionary<MediaFormat, bool>
   {
      { MediaFormat.TV, true }, // set to only search for TV shows and movies
      { MediaFormat.Movie, true },
      { MediaFormat.TVShort, false } // set to not show TV shorts
   }
});

foreach (var result in results.Data) // prints all results into console
   Console.WriteLine(result.Title.EnglishTitle);
```

For more examples for using this library, visit the [usages wiki](https://github.com/dentolos19/AniListNet/wiki/Usages) or check out the [unit tests](./AniListNet.Tests).

## ⚙️ Features

> **Note**: This library does not fully implements the API, so some features might be missing.

- [X] Has search query functions
    - [X] `SearchMediaAsync`: searches for Anime & Manga (supports filtering)
    - [X] `SearchCharacterAsync`: searches for characters (supports filtering)
    - [X] `SearchStaffAsync`
    - [X] `SearchStudioAsync`
    - [X] `SearchUserAsync`
- [X] Has data query functions
    - [X] `GetGenreCollectionAsync`: gets all supported genres (e.g. Action, Fantasy, Romance)
    - [X] `GetTagCollectionAsync`: gets all supported tags (e.g. Male Protagonist, Heterosexual, Cultivation)
    - [X] `GetMediaAsync`
    - [X] `GetMediaSchedulesAsync`: supports filtering
    - [X] `GetCharacterAsync`
    - [X] `GetStaffAsync`
    - [X] `GetStudioAsync`
    - [X] `GetUserAsync`
- [X] Has specific data query functions
    - [X] `GetCharacterMediaAsync`
    - [X] `GetStaffMediaAsync`
    - [X] `GetStaffProductionMediaAsync`
    - [X] `GetStaffVoicedMediaAsync`
    - [X] `GetStaffVoicedCharactersAsync`
    - [X] `GetStudioMediaAsync`
- [X] Has media-specific data query functions
    - [X] `GetMediaRelationsAsync`
    - [X] `GetMediaCharactersAsync`
    - [X] `GetMediaStaffAsync`
    - [X] `GetMediaStudiosAsync`
- [X] Has user-specific data query functions
    - [X] `GetUserFollowersAsync`
    - [X] `GetUserFollowingsAsync`
    - [X] `GetUserEntriesAsync`
    - [X] `GetUserEntryCollectionAsync`
    - [X] `GetUserAnimeFavoritesAsync`
    - [X] `GetUserMangaFavoritesAsync`
    - [X] `GetUserCharacterFavoritesAsync`
    - [X] `GetUserStaffFavoritesAsync`
    - [X] `GetUserStudioFavoritesAsync`
- [X] Has user-only mutation functions
    - [X] `TryAuthenticateAsync`: authenticate with user's access token
    - [X] `GetAuthenticatedUserAsync`
    - [X] `UpdateUserOptionsAsync`
    - [X] `SaveMediaEntryAsync`
    - [X] `DeleteMediaEntryAsync`
    - [X] `ToggleFollowUserAsync`
    - [X] `ToggleMediaFavoriteAsync`
    - [X] `ToggleCharacterFavoriteAsync`
    - [X] `ToggleStaffFavoriteAsync`
    - [X] `ToggleStudioFavoriteAsync`