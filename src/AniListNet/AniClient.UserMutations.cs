using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    public async Task<User> GetAuthenticatedUserAsync()
    {
        var selections = new GqlSelection("Viewer", GqlParser.ParseType(typeof(User)));
        var response = await PostRequestAsync(selections);
        return response["Viewer"].ToObject<User>();
    }

    public async Task<User> UpdateUserOptionsAsync(UserOptionsMutation mutation)
    {
        var selections = new GqlSelection("UpdateUser", typeof(User).ToSelections(), mutation.ToParameters());
        var response = await PostRequestAsync(selections, true);
        return response["UpdateUser"].ToObject<User>();
    }

    public async Task<MediaEntry> SaveMediaEntryAsync(int mediaId, MediaEntryMutation mutation)
    {
        var parameters = new List<GqlParameter> { new("mediaId", mediaId) }.Concat(mutation.ToParameters());
        var selections = new GqlSelection("SaveMediaListEntry", typeof(MediaEntry).ToSelections(), parameters.ToArray());
        var response = await PostRequestAsync(selections, true);
        return response["SaveMediaListEntry"].ToObject<MediaEntry>();
    }

    public async Task<bool> DeleteMediaEntryAsync(int mediaId)
    {
        var selections = new GqlSelection("DeleteMediaListEntry", new GqlSelection[]
        {
            new("deleted")
        }, new GqlParameter[]
        {
            new("id", mediaId)
        });
        var response = await PostRequestAsync(selections, true);
        return response["DeleteMediaListEntry"]["deleted"].ToObject<bool>();
    }

    public async Task<bool> ToggleFollowUserAsync(int mediaId)
    {
        var selections = new GqlSelection("ToggleFollow", new GqlSelection[]
        {
            new("isFollowing")
        }, new GqlParameter[]
        {
            new("userId", mediaId)
        });
        var response = await PostRequestAsync(selections, true);
        return response["ToggleFollow"]["isFollowing"].ToObject<bool>();
    }

    public async Task<bool> ToggleMediaFavoriteAsync(int mediaId, MediaType type)
    {
        await ToggleFavoriteAsync(type switch
        {
            MediaType.Anime => "animeId",
            MediaType.Manga => "mangaId"
        }, mediaId);
        return (await GetSingleDataAsync(
            new GqlSelection("Media", default, new GqlParameter[]
            {
                new("id", mediaId)
            }),
            new GqlSelection("isFavourite")
        )).ToObject<bool>();
    }

    public async Task<bool> ToggleCharacterFavoriteAsync(int characterId)
    {
        await ToggleFavoriteAsync("characterId", characterId);
        return (await GetSingleDataAsync(
            new GqlSelection("Character", default, new GqlParameter[]
            {
                new("id", characterId)
            }),
            new GqlSelection("isFavourite")
        )).ToObject<bool>();
    }

    public async Task<bool> ToggleStaffFavoriteAsync(int staffId)
    {
        await ToggleFavoriteAsync("staffId", staffId);
        return (await GetSingleDataAsync(
            new GqlSelection("Staff", default, new GqlParameter[]
            {
                new("id", staffId)
            }),
            new GqlSelection("isFavourite")
        )).ToObject<bool>();
    }

    public async Task<bool> ToggleStudioFavoriteAsync(int studioId)
    {
        await ToggleFavoriteAsync("studioId", studioId);
        return (await GetSingleDataAsync(
            new GqlSelection("Studio", default, new GqlParameter[]
            {
                new("id", studioId)
            }),
            new GqlSelection("isFavourite")
        )).ToObject<bool>();
    }

    /* below are methods made for private use */

    private async Task ToggleFavoriteAsync(string field, int id)
    {
        var selections = new GqlSelection("ToggleFavourite", new GqlSelection[]
        {
            new("anime", new GqlSelection[]
            {
                new("pageInfo", new GqlSelection[]
                {
                    new("total")
                })
            })
        }, new GqlParameter[]
        {
            new(field, id)
        });
        _ = await PostRequestAsync(selections, true);
    }
}