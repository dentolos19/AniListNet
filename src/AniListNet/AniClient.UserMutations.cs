﻿using AniListNet.Helpers;
using AniListNet.Objects;
using AniListNet.Parameters;

namespace AniListNet;

public partial class AniClient
{
    public async Task<User> GetAuthenticatedUserAsync()
    {
        var selections = new GqlSelection("Viewer")
        {
            Selections = GqlParser.ParseToSelections<User>()
        };
        var response = await PostRequestAsync(selections);
        return GqlParser.ParseFromJson<User>(response["Viewer"]);
    }

    public async Task<User> UpdateUserOptionsAsync(UserOptionsMutation mutation)
    {
        var selections = new GqlSelection("UpdateUser")
        {
            Parameters = mutation.ToParameters(),
            Selections = GqlParser.ParseToSelections<User>()
        };
        var response = await PostRequestAsync(selections, true);
        return GqlParser.ParseFromJson<User>(response["UpdateUser"]);
    }

    /// <summary>
    /// Create or update a media entry.
    /// </summary>
    public async Task<MediaEntry> SaveMediaEntryAsync(int mediaId, MediaEntryMutation mutation)
    {
        var selections = new GqlSelection("SaveMediaListEntry")
        {
            Parameters = new GqlParameter[] { new("mediaId", mediaId) }.Concat(mutation.ToParameters()).ToArray(),
            Selections = GqlParser.ParseToSelections<MediaEntry>()
        };
        var response = await PostRequestAsync(selections, true);
        return GqlParser.ParseFromJson<MediaEntry>(response["SaveMediaListEntry"]);
    }

    /// <summary>
    /// Delete a media entry.
    /// </summary>
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
        return GqlParser.ParseFromJson<bool>(response["DeleteMediaListEntry"]["deleted"]);
    }

    /// <summary>
    /// Create or update a review.
    /// </summary>
    public async Task<MediaReview> SaveMediaReviewAsync(int mediaId, MediaReviewMutation mutation)
    {
        var parameters = new List<GqlParameter> { new("mediaId", mediaId) }.Concat(mutation.ToParameters());
        var selections = new GqlSelection("SaveReview", GqlParser.ParseToSelections<MediaReview>(), parameters.ToArray());
        var response = await PostRequestAsync(selections, true);
        return GqlParser.ParseFromJson<MediaReview>(response["SaveReview"]);
    }

    /// <summary>
    /// Delete a review.
    /// </summary>
    public async Task<bool> DeleteMediaReviewAsync(int reviewId)
    {
        var selections = new GqlSelection("DeleteReview", new GqlSelection[]
        {
            new("deleted")
        }, new GqlParameter[]
        {
            new("id", reviewId)
        });
        var response = await PostRequestAsync(selections, true);
        return GqlParser.ParseFromJson<bool>(response["DeleteReview"]["deleted"]);
    }

    /// <summary>
    /// Rate a review.
    /// </summary>
    public async Task<MediaReview> RateMediaReviewAsync(int reviewId, MediaReviewRating rating)
    {
        var parameters = new List<GqlParameter> { new("reviewId", reviewId), new("rating", rating) };
        var selections = new GqlSelection("RateReview", GqlParser.ParseToSelections<MediaReview>(), parameters.ToArray());
        var response = await PostRequestAsync(selections, true);
        return GqlParser.ParseFromJson<MediaReview>(response["RateReview"]);
    }

    /// <summary>
    /// Save a recommendation on a media.
    /// </summary>
    public async Task<MediaRecommendation> SaveMediaRecommendationAsync(int mediaId, MediaRecommendationMutation mutation)
    {
        var parameters = new List<GqlParameter> { new("mediaId", mediaId) }.Concat(mutation.ToParameters());
        var selections = new GqlSelection("SaveRecommendation", GqlParser.ParseToSelections<MediaRecommendation>(), parameters.ToArray());
        var response = await PostRequestAsync(selections, true);
        return GqlParser.ParseFromJson<MediaRecommendation>(response["SaveRecommendation"]);
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
        return GqlParser.ParseFromJson<bool>(response["ToggleFollow"]["isFollowing"]);
    }

    public async Task<bool> ToggleMediaFavoriteAsync(int mediaId, MediaType type)
    {
        await ToggleFavoriteAsync(type switch
        {
            MediaType.Anime => "animeId",
            MediaType.Manga => "mangaId"
        }, mediaId);
        var json = await GetSingleDataAsync(
            new GqlSelection("Media", default, new GqlParameter[] { new("id", mediaId) }),
            new GqlSelection("isFavourite")
        );
        return GqlParser.ParseFromJson<bool>(json);
    }

    public async Task<bool> ToggleCharacterFavoriteAsync(int characterId)
    {
        await ToggleFavoriteAsync("characterId", characterId);
        var json = await GetSingleDataAsync(
            new GqlSelection("Character", default, new GqlParameter[] { new("id", characterId) }),
            new GqlSelection("isFavourite")
        );
        return GqlParser.ParseFromJson<bool>(json);
    }

    public async Task<bool> ToggleStaffFavoriteAsync(int staffId)
    {
        await ToggleFavoriteAsync("staffId", staffId);
        var json = await GetSingleDataAsync(
            new GqlSelection("Staff", default, new GqlParameter[] { new("id", staffId) }),
            new GqlSelection("isFavourite")
        );
        return GqlParser.ParseFromJson<bool>(json);
    }

    public async Task<bool> ToggleStudioFavoriteAsync(int studioId)
    {
        await ToggleFavoriteAsync("studioId", studioId);
        var json = await GetSingleDataAsync(
            new GqlSelection("Studio", default, new GqlParameter[]
            {
                new("id", studioId)
            }),
            new GqlSelection("isFavourite")
        );
        return GqlParser.ParseFromJson<bool>(json);
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