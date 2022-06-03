﻿using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet;

public partial class AniClient
{

    public async Task<string[]> GetGenreCollectionAsync()
    {
        var response = await PostRequestAsync(new GqlSelection("GenreCollection"));
        return response["GenreCollection"].ToObject<string[]>();
    }

    public async Task<MediaTag[]> GetTagCollectionAsync()
    {
        var response = await PostRequestAsync(new GqlSelection("MediaTagCollection", GqlParser.ParseType(typeof(MediaTag))));
        return response["MediaTagCollection"].ToObject<MediaTag[]>();
    }

    public async Task<Media> GetMediaAsync(int id)
    {
        var response = await PostRequestAsync(
            new GqlSelection("Media", GqlParser.ParseType(typeof(Media)), new GqlParameter[]
            {
                new("id", id)
            })
        );
        return response["Media"].ToObject<Media>();
    }

    public async Task<AniPagination<MediaSchedule>> GetMediaSchedulesAsync(AniPaginationOptions? options = null)
    {
        options ??= new AniPaginationOptions();
        var response = await PostRequestAsync(
            new GqlSelection("Page", new GqlSelection[]
            {
                new("pageInfo", GqlParser.ParseType(typeof(PageInfo))),
                new("airingSchedules", GqlParser.ParseType(typeof(MediaSchedule)), new GqlParameter[]
                {
                    new("notYetAired", true)
                })
            }, new GqlParameter[]
            {
                new("page", options.PageIndex),
                new("perPage", options.PageSize)
            })
        );
        return new AniPagination<MediaSchedule>(
            response["Page"]["pageInfo"].ToObject<PageInfo>(),
            response["Page"]["airingSchedules"].ToObject<MediaSchedule[]>()
        );
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Character", GqlParser.ParseType(typeof(Character)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await PostRequestAsync(request);
        return response["Character"].ToObject<Character>();
    }

    public async Task<Staff> GetStaffAsync(int id)
    {
        var request = GqlParser.ParseSelection(new GqlSelection("Staff", GqlParser.ParseType(typeof(Staff)), new GqlParameter[]
        {
            new("id", id)
        }));
        var response = await PostRequestAsync(request);
        return response["Staff"].ToObject<Staff>();
    }

    public async Task<Studio> GetStudioAsync(int id)
    {
        var response = await PostRequestAsync(
            new GqlSelection("Studio", GqlParser.ParseType(typeof(Studio)), new GqlParameter[]
            {
                new("id", id)
            })
        );
        return response["Studio"].ToObject<Studio>();
    }

    public async Task<User> GetUserAsync(int id)
    {
        var response = await PostRequestAsync(
            new GqlSelection("User", GqlParser.ParseType(typeof(User)), new GqlParameter[]
            {
                new("id", id)
            })
        );
        return response["User"].ToObject<User>();
    }

}