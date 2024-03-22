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
  - [x] `GetMediaReviewAsync`
  - [x] `GetMediaSchedulesAsync`: supports filtering
  - [x] `GetTrendingMediaAsync`
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
  - [x] `GetMediaRecommendationsAsync`
  - [x] `GetMediaReviewsAsync`
- [x] Has user-specific data query functions
  - [x] `GetUserFollowersAsync`
  - [x] `GetUserFollowingsAsync`
  - [x] `GetUserEntriesAsync`
  - [x] `GetUserEntryCollectionAsync`
  - [x] `GetUserListCollectionAsync`: similar to `GetUserEntryCollectionAsync`, but comes without its media entries
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