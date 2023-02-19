# <img src="docs/icon.png" width="48px"/> AniList.NET [![](https://img.shields.io/nuget/v/AniListNet?label=NuGet&logo=nuget&style=flat-square)](https://nuget.org/packages/AniListNet)

A simple .NET API wrapper for [AniList](https://anilist.co)!

This project is designed to bring you a simpler way to access and interact with the AniList API. For more information
about the API itself, visit [AniList APIv2 docs](https://anilist.gitbook.io/anilist-apiv2-docs).

> **Note**: This was formerly a side project of [Otakulore](https://github.com/dentolos19/Otakulore), now it's a fully-fledged project!

## ⚒️ Usage

Install the library in your project.

- .NET CLI: `dotnet add package AniListNet`
- Package Manager CLI: `Install-Package AniListNet`

```cs
using AniListNet;
using AniListNet.Objects;
using AniListNet.Parameters;

// a simple class that fulfils all your needs
var client = new AniClient();

// easy authentication with AniList
var isAuthenticated = await client.TryAuthenticateAsync("<AUTH_TOKEN>");
if (!isAuthenticated)
  throw new Exception("Unable to authenticate with AniList.");

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

For more examples for using this library, visit the [usages wiki](https://github.com/dentolos19/AniListNet/wiki/Usages)
or check out the [unit tests](./AniListNet.Tests).

## ⚙️ Features

> **Note**: This library does not fully implements the API, so some features might be missing.

- [x] Has search query functions
  - [x] `SearchMediaAsync`: searches for Anime & Manga (supports filtering)
  - [x] `SearchCharacterAsync`: searches for characters (supports filtering)
  - [x] `SearchStaffAsync`
  - [x] `SearchStudioAsync`
  - [x] `SearchUserAsync`
- [x] Has data query functions
  - [x] `GetGenreCollectionAsync`: gets all supported genres (e.g. Action, Fantasy, Romance)
  - [x] `GetTagCollectionAsync`: gets all supported tags (e.g. Male Protagonist, Heterosexual, Cultivation)
  - [x] `GetMediaAsync`
  - [x] `GetMediaSchedulesAsync`: supports filtering
  - [x] `GetCharacterAsync`
  - [x] `GetStaffAsync`
  - [x] `GetStudioAsync`
  - [x] `GetUserAsync`
- [x] Has specific data query functions
  - [x] `GetCharacterMediaAsync`
  - [x] `GetStaffMediaAsync`
  - [x] `GetStaffProductionMediaAsync`
  - [x] `GetStaffVoicedMediaAsync`
  - [x] `GetStaffVoicedCharactersAsync`
  - [x] `GetStudioMediaAsync`
- [x] Has media-specific data query functions
  - [x] `GetMediaRelationsAsync`
  - [x] `GetMediaCharactersAsync`
  - [x] `GetMediaStaffAsync`
  - [x] `GetMediaStudiosAsync`
- [x] Has user-specific data query functions
  - [x] `GetUserFollowersAsync`
  - [x] `GetUserFollowingsAsync`
  - [x] `GetUserEntriesAsync`
  - [x] `GetUserEntryCollectionAsync`
  - [x] `GetUserListCollectionAsync`: similar to the previous function; but comes without its media entries
  - [x] `GetUserAnimeFavoritesAsync`
  - [x] `GetUserMangaFavoritesAsync`
  - [x] `GetUserCharacterFavoritesAsync`
  - [x] `GetUserStaffFavoritesAsync`
  - [x] `GetUserStudioFavoritesAsync`
- [x] Has user-only mutation functions
  - [x] `TryAuthenticateAsync`: authenticate with user's access token
  - [x] `GetAuthenticatedUserAsync`
  - [x] `UpdateUserOptionsAsync`
  - [x] `SaveMediaEntryAsync`
  - [x] `DeleteMediaEntryAsync`
  - [x] `ToggleFollowUserAsync`
  - [x] `ToggleMediaFavoriteAsync`
  - [x] `ToggleCharacterFavoriteAsync`
  - [x] `ToggleStaffFavoriteAsync`
  - [x] `ToggleStudioFavoriteAsync`

## 🔨 Todo

- [ ] Add query functions for notification data
- [ ] Add query/mutations functions for user settings/activities
- [ ] Add query/mutations functions for forums
- [ ] Add more options for filtering
- [ ] Add more data for `User`
- [ ] Use generics instead of arrays