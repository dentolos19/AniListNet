<h1>
    <img src="docs/icon.png" style="height: 1em"/>
    <span>AniList.NET</span>
</h1>

[![NuGet Version](https://img.shields.io/nuget/v/AniListNet?logo=nuget)](https://nuget.org/packages/AniListNet)
[![NuGet Downloads](https://img.shields.io/nuget/dt/AniListNet)](https://nuget.org/packages/AniListNet)

A simple .NET API wrapper for [AniList](https://anilist.co)!

This project is designed to bring you a simpler way to access and interact with the AniList API. For more information
about the API itself, visit [AniList APIv2 docs](https://anilist.gitbook.io/anilist-apiv2-docs).

## ⚒️ Usage

Install the package in your project.

- .NET CLI: `dotnet add package AniListNet`
- Package Manager CLI: `Install-Package AniListNet`

```cs
using AniListNet;
using AniListNet.Objects;
using AniListNet.Parameters;

// A simple class that fulfils all your needs
var client = new AniClient();

// Easy authentication with AniList
var isAuthenticated = await client.TryAuthenticateAsync("<AUTH_TOKEN>");
if (!isAuthenticated)
  throw new Exception("Unable to authenticate with AniList!");

var results = await client.SearchMediaAsync(new SearchMediaFilter
{
   Query = "one piece", // The term to search for
   Type = MediaType.Anime, // Filters search results to anime only
   Sort = MediaSort.Popularity, // Sorts them by popularity
   Format = new Dictionary<MediaFormat, bool>
   {
      { MediaFormat.TV, true }, // Set to only search for TV shows and movies
      { MediaFormat.Movie, true },
      { MediaFormat.TVShort, false } // Set to not show TV shorts
   }
});

foreach (var result in results.Data) // Prints all results into console
   Console.WriteLine(result.Title.EnglishTitle);
```

To see more examples, go check out [the wiki](https://github.com/dentolos19/AniListNet/wiki)!

## ⚙️ Features

> **Note**: This library does not fully implement the API, so some features might be missing.

- [x] Authenticate and login with AniList!
- [x] Search for anime, manga, staff, studio and users! With filter support.
- [x] Get intricate details about any anime or manga like relations, characters, staff, studios, and more!
- [x] Get intricate details about any character or staff like which anime and manga they appeared in or worked on!
- [x] Get user details like followers, entries, collections, and favorites!
- [x] Update a user's followings, entries and favorites easily!

## 🔨 Roadmap

- [ ] Add query functions for notification data
- [ ] Add query/mutations functions for user activities
- [ ] Use same naming conventions for object data (target v2)
- [ ] Use generics instead of arrays (target v2)

## 🧑‍💻 Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

### Prerequisites

- [.NET](https://dot.net) 6+

### Installation

1. Clone the repo: `git clone https://github.com/dentolos19/AniListNet.git`
2. Get your API key, learn how by [clicking here](https://github.com/dentolos19/AniListNet/wiki/Tutorials#authenticating-with-anilist).
3. Use the template `.env.template` and create a file named `.env` inside the project `AniListNet.Tests` and enter your key.
4. Restore dependencies: `dotnet restore` (optional)
5. Test the library: `dotnet test` or use the built-in tests runner in your IDE (recommended)

## 💖 Credits

- **Icon** from [AniList](https://anilist.co), edited by me.

## 📜 License

Distributed under the MIT License. See [LICENSE](LICENSE) for more information.