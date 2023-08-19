using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;

namespace ParsingData.Importer
{
    public class GameImporter
    {
        private readonly GameShopContext _shopContext;

        public GameImporter(GameShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<GamesEntity> CreateGame(GamesEntity game, DevelopersEntity developer)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            var game1 = await _shopContext.Games.FirstOrDefaultAsync(g => g.Name == game.Name);
            if (game1 != null)
            {
                var existDevAtGame = await _shopContext.GamesToDevelopers.FirstOrDefaultAsync(x => x.DeveloperId == developer.Id && x.GameId == game1.Id);

                if (game1.GamesToDevelopers is null)
                {
                    game1.GamesToDevelopers = new List<GamesToDeveloperEntity>();
                }

                if (existDevAtGame != null)
                {
                    return game1;
                }

                if ((game1.GamesToDevelopers.Count == 0 || game1.GamesToDevelopers.Count > 0 ) && existDevAtGame == null)
                {

                    game1.GamesToDevelopers.Add(new Domain.Entities.GamesToDeveloperEntity()
                    {
                        DeveloperId = (int)developer.Id,
                        GameId = (int)game1.Id,
                    });
                }

                return game1;
            }            
            
            
            game.ESRB_Rating = await GetAndUpdateExistingEsrbRatingAsync(game.ESRB_Rating);

            ESRBRatingEntity eSRBRating = new ESRBRatingEntity();

            if (game.ESRB_Rating == null)
            {
                eSRBRating.Name = game.ESRB_Rating.Name;
                eSRBRating.Slug = game.ESRB_Rating.Slug;
            }

            game.Platforms = await GetAndUpdateExistingPlatformsAsync(game.Platforms);

            game.Genres = await GetAndUpdateExistingGenresAsync(game.Genres);

            game.Stores = await GetAndUpdateExistingStoresAsync(game.Stores);

            game.Ratings = await GetAndUpdateExistingRatingsAsync(game.Ratings);

            game.Tags = await GetAndUpdateExistingTagsAsync(game.Tags);

            List<ShortScreenshotEntity> shortScreenshots = game.Short_Screenshots?.Select(g => new ShortScreenshotEntity()
            {
                Game = g.Game,
                Image = g.Image,
            }).ToList() ?? new List<ShortScreenshotEntity>();

            if (game.Metacritic is null)
            {
                game.Metacritic = 0;
            }

            var newGame = new GamesEntity()
            {
                Added_By_Status = game.Added_By_Status ?? new Domain.Entities.AddedByStatusEntity(),
                Name = game.Name,
                Background_Image = game.Background_Image,
                ESRB_Rating = game.ESRB_Rating ?? eSRBRating,
                Short_Screenshots = shortScreenshots,
                Genres = game.Genres ?? new List<GenreEntity>(),
                Platforms = game.Platforms ?? new List<PlatformEntity>(),
                Ratings = game.Ratings ?? new List<RatingEntity>(),
                Tags = game.Tags ?? new List<TagEntity>(),
                Metacritic = game.Metacritic,
                Playtime = game.Playtime,
                Rating = game.Rating,
                Rating_Top = game.Rating_Top,
                Ratings_Count = game.Ratings_Count,
                Released = game.Released,
                Reviews_Count = game.Reviews_Count,
                Reviews_Text_Count = game.Reviews_Text_Count,
                Slug = game.Slug,
                Suggestions_Count = game.Suggestions_Count,
                Tba = game.Tba,
                Updated = game.Updated,
                Stores = game.Stores ?? new List<StoreEntity>(),
                GamesToDevelopers = new List<GamesToDeveloperEntity>()
                {
                    new Domain.Entities.GamesToDeveloperEntity()
                    {
                        DeveloperId = (int)developer.Id,
                    }
                },
                GamesToGenres = new List<GamesToGenresEntity>(),
                GamesToRatings = new List<GamesToRatingEntity>(),
                GamesToPlatfrorms = new List<GamesToPlatfrormEntity>(),
                GamesToStores = new List<GamesToStoresEntity>(),
                GamesToTags = new List<GamesToTagsEntity>(),
                GameToShortScreenshots = new List<GamesToScreenshotsEntity>(),
            };

            return newGame;
        }

        private async Task<List<PlatformEntity>> GetAndUpdateExistingPlatformsAsync(List<PlatformEntity> platforms)
        {
            if(platforms is null)
            {
                platforms = new List<PlatformEntity>();
            }

            var existingPlatforms = new List<PlatformEntity>();
            foreach (var platform in platforms)
            {
                var existingPlatform = await _shopContext.PlatformModels
                    .FirstOrDefaultAsync(p => p.Platform.Name == platform.Platform.Name);

                var existPlatformInfoModel = await _shopContext.PlatformInfoModels
                    .FirstOrDefaultAsync(p => p.Name == platform.Platform.Name);

                if (existingPlatform != null || existPlatformInfoModel != null)
                {
                    existingPlatform.Platform = existPlatformInfoModel;
                    existingPlatforms.Add(existingPlatform);
                }
                else
                {
                    platform.GamesToPlatfrorms = platform.GamesToPlatfrorms;
                    platform.Platform = new Domain.Entities.PlatformInfoEntity()
                    {
                        Name = platform.Platform.Name,
                        Slug = platform.Platform.Slug,
                        Year_End = platform.Platform.Year_End,
                        Year_start = platform.Platform.Year_start,
                        Image = platform.Platform.Image,
                        Image_Background = platform.Platform.Image_Background,
                        Games_Count = platform.Platform.Games_Count,
                    };
                }
            }

            if(existingPlatforms.Count <= 0) 
            {
                return platforms;
            }

            return existingPlatforms;
        }

        private async Task<List<GenreEntity>> GetAndUpdateExistingGenresAsync(List<GenreEntity> genres)
        {
            if(genres is null)
            {
                genres = new List<GenreEntity>();
            }

            var notExistGenres = new List<GenreEntity>();
            var existingPlatforms = new List<GenreEntity>();
            foreach (var genre in genres)
            {
                var existingGenre = await _shopContext.Genres
                    .FirstOrDefaultAsync(p => p.Name == genre.Name);

                if (existingGenre != null)
                {
                    existingPlatforms.Add(existingGenre);
                }
                else
                {
                    var newGenre = new GenreEntity()
                    {
                        Name = genre.Name,
                        Slug = genre.Slug,
                        GamesCount = genre.GamesCount,
                        GamesToGenres = genre.GamesToGenres,
                    };
                    notExistGenres.Add(newGenre);
                }
            }

            if (existingPlatforms.Count <= 0)
            {
                return notExistGenres;
            }

            return existingPlatforms;
        }

        private async Task<List<StoreEntity>> GetAndUpdateExistingStoresAsync(List<StoreEntity> stores)
        {
            if(stores is null)
            {
                stores = new List<StoreEntity>();
            }
            var existingStores = new List<StoreEntity>();
            var noteExistingStores = new List<StoreEntity>();
            foreach (var store in stores)
            {
                var existingStore = await _shopContext.StoreModels
                    .FirstOrDefaultAsync(p => p.Store.Name == store.Store.Name);

                var existStoreInfoModel = await _shopContext.StoreInfoModels
                    .FirstOrDefaultAsync(p => p.Name == store.Store.Name);

                if (existingStore != null || existStoreInfoModel != null)
                {
                    if (existStoreInfoModel != null)
                    {
                        existingStore.Id = existStoreInfoModel.Id;
                    }
                    existingStore.Store = existStoreInfoModel;
                    existingStores.Add(existingStore);
                }
                else
                {
                    noteExistingStores.Add(new StoreEntity()
                    {
                        Store = new Domain.Entities.StoreInfoEntity()
                        {
                            Name = store.Store.Name,
                            Slug = store.Store.Slug,
                            Domain = store.Store.Domain,
                            Games_Count = store.Store.Games_Count,
                        },
                        GamesToStores = store.GamesToStores,
                    });
                }
            }

            if (existingStores.Count <= 0)
            {
                return noteExistingStores;
            }

            return existingStores;
        }

        private async Task<List<RatingEntity>> GetAndUpdateExistingRatingsAsync(List<RatingEntity> ratings)
        {
            if(ratings is null)
            {
                ratings = new List<RatingEntity>();
            }

            var notExistRatings = new List<RatingEntity>();
            var existingRatings = new List<RatingEntity>();
            foreach (var store in ratings)
            {
                var existingRating = await _shopContext.RatingModels
                    .FirstOrDefaultAsync(p => p.Title == store.Title);

                if (existingRating != null)
                {
                    existingRatings.Add(existingRating);
                }
                else
                {
                    var rating = new RatingEntity()
                    {
                        Title = store.Title,
                        Percent = store.Percent,
                        Count = store.Count,
                        GamesToRatings = store.GamesToRatings,
                    };
                    notExistRatings.Add(rating);
                }
            }

            if (existingRatings.Count <= 0)
            {
                return notExistRatings;
            }

            return existingRatings;
        }

        private async Task<List<TagEntity>> GetAndUpdateExistingTagsAsync(List<TagEntity> tags)
        {
            if(tags is null)
            {
                tags = new List<TagEntity>();
            }

            var notExistTags = new List<TagEntity>();
            var existingTags = new List<TagEntity>();
            foreach (var tag in tags)
            {
                var existingTag = await _shopContext.Tags
                    .FirstOrDefaultAsync(p => p.Name == tag.Name);

                if (existingTag != null)
                {
                    existingTags.Add(existingTag);
                }
                else
                {
                    var tag1 = new TagEntity()
                    {
                        Name = tag.Name,
                        Slug = tag.Slug,
                        Image_Background = tag.Image_Background,
                        Language = tag.Language,
                        Games_Count = tag.Games_Count,
                        ToTagsModels = tag.ToTagsModels,
                    };
                    notExistTags.Add(tag1);
                }
            }

            if (existingTags.Count <= 0)
            {
                return notExistTags;
            }

            return existingTags;
        }

        private async Task<ESRBRatingEntity> GetAndUpdateExistingEsrbRatingAsync(ESRBRatingEntity eSRBRating)
        {
            if(eSRBRating is null)
            {
                eSRBRating = new ESRBRatingEntity()
                {
                    Name = "Non defined",
                    Slug = "non_def",
                };
            }
            var existingeSRBRating = new ESRBRatingEntity();

            existingeSRBRating = await _shopContext.ESRBRatings
                     .FirstOrDefaultAsync(p => p.Name == eSRBRating.Name);

            if (existingeSRBRating == null)
            {
                if(eSRBRating != null)
                {
                    eSRBRating = new ESRBRatingEntity()
                    {
                        Name = eSRBRating.Name,
                        Slug = eSRBRating.Slug,
                    };
                }
                return eSRBRating;
            }

            return existingeSRBRating;
        }
    }
}
