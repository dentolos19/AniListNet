Welcome to **AniList.NET**'s wiki!

## Getting Started

> **Note**: You need to have a [.NET Standard 2.1 compatible framework](https://learn.microsoft.com/dotnet/standard/net-standard?tabs=net-standard-2-1#select-net-standard-version) in order to be able to use this in your project!

Install the package inside your project via CLI or the package manager.

```
dotnet add package AniListNet
```

Then, inside your file, import the required namespaces.

```cs
using AniListNet; // Contains base classes for interacting with the API
using AniListNet.Parameters; // Contains classes for mutation and filtering
using AniListNet.Objects; // Contains model classes for handling data
```

Create the client.

```cs
var client = new AniClient();
```

And if you have a token, you may attempt to authenticate with the API.

```cs
var isAuthenticated = await client.TryAuthenticateAsync("<YOUR_TOKEN_HERE>");
if (!isAuthenticated)
  throw new Exception("Unable to authenticate with AniList!");
```

You can now access AniList's API!

```cs
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

You're all set! 😁 If you want to learn more, check out [the tutorials page](./Tutorials).