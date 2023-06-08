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

> **Note**: This library does not fully implement the API, so some features might be missing.

- [x] Authenticate and login with AniList!
- [x] Search for anime, manga, staff, studio and users! With filter support.
- [x] Get intricate details about any anime or manga like relations, characters, staff, studios, and more!
- [x] Get intricate details about any character or staff like which anime and manga they appeared in or worked on!
- [x] Get user details like followers, entries, collections, and favorites!
- [x] Update a user's followings, entries and favorites easily!

See more features by visiting the [features wiki](https://github.com/dentolos19/AniListNet/wiki/Features).

## 🔨 Todo

- [ ] Add query functions for notification data
- [ ] Add query/mutations functions for user settings/activities
- [ ] Add query/mutations functions for forums
- [ ] Add more options for filtering
- [ ] Add more data for `User`
- [ ] Use generics instead of arrays