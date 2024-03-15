## Authenticating with AniList

In order to access a user's profile in AniList, we need be given approval and an access token from the website.

There's two ways to request for a user's access token which are [Authorization Code Grant](https://anilist.gitbook.io/anilist-apiv2-docs/overview/oauth/authorization-code-grant) and [Implicit Grant](https://anilist.gitbook.io/anilist-apiv2-docs/overview/oauth/implicit-grant). We will be using Implicit Grant which is commonly used in JavaScript or mobile applications where your client credentials can't be safely secured.

> **Note**: Make sure your application is able to display/redirect to a web page. And also I will not be providing examples here because your application can be anything from a website to a desktop application so I can't be specific. If you want an example, check out [Otakulore](https://github.com/dentolos19/Otakulore).

1. Create an API client through the [settings](https://anilist.co/settings/developer) and get the 4-digit client ID.
2. Have the application navigate to `https://anilist.co/api/v2/oauth/authorize?client_id=<CLIENT_ID>&response_type=token` and paste your client ID inside.
3. Once the user has logged in and navigated to your **Redirect URL**, regex the URL with `(?<=access_token=)(.*)(?=&token_type)` and retrieve the string.
4. Authenticate with the access token: `AniClient.TryAuthenticateAsync("<ACCESS_TOKEN>")`.
5. If the method returned `true`, then you have successfully authenticated with AniList!

Learn more about this from the [official docs](https://anilist.gitbook.io/anilist-apiv2-docs/overview/oauth/getting-started).

## Filtering Search Queries

In this example, we will be searching for an Anime with the search term "One Piece" by popularity with a couple of filters.

```cs
var filter = new SearchMediaFilter
{
    Query = "One Piece", // our search term
    Sort = MediaSort.Popularity, // sort results by popularity
    Type = MediaType.Anime, // only show Anime media
    Genres = new Dictionary<string, bool>
    {
        { "Action", true }, // by setting the value to true, it will filter to media containing it
        { "Fantasy", true },
        { "Romance", false } // by setting the value to false, it will filter to media not containing it
    }
};
var results = await AniClient.SearchMediaAsync(filter);
```

## Paginating Results

In this example, we will be paginating results that has a next page.

```cs
var firstResults = await AniClient.SearchMediaAsync("One Piece", new AniPaginationOptions(1, 20)); // request for page 1 with 20 items
var secondResults = await AniClient.SearchMediaAsync("One Piece", new AniPaginationOptions(2, 20)); // request for page 2 with 20 items
```

> **Note**: When paginating results, we recommend that you don't change any properties such as the query or the amount of requested items.