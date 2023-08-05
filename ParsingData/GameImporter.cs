using Infrastructure.Context;
using Domain.Entities.Developer;
using Domain.Entities.ESRBRating;
using Domain.Entities.Games;
using Domain.Entities.Genres;
using Domain.Entities.Platform;
using Domain.Entities.Rating;
using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using Domain.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using System;

namespace ParsingData
{
    public class GameImporter
    {
        private readonly GameShopContext _shopContext;

        public GameImporter(GameShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<GamesModel> CreateGame(GamesModel game, DevelopersModel developer)
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
                    game1.GamesToDevelopers = new List<Domain.Entities.GamesToDeveloper.GamesToDeveloperModel>();
                }

                if (existDevAtGame == null)
                {
                    game1.GamesToDevelopers.Add(new Domain.Entities.GamesToDeveloper.GamesToDeveloperModel()
                    {
                        Developer = developer,
                        DeveloperId = (int)developer.Id,
                    });

                    return game1;
                }
                if (game1.GamesToDevelopers.Count == 0 || game1.GamesToDevelopers.Count > 0)
                {

                    game1.GamesToDevelopers.Add(new Domain.Entities.GamesToDeveloper.GamesToDeveloperModel()
                    {
                        DeveloperId = (int)developer.Id,
                        GameId = (int)game1.Id,
                    });
                }

                return game1;
            }            
            
            
            game.ESRB_Rating = await GetAndUpdateExistingEsrbRatingAsync(game.ESRB_Rating);

            ESRBRatingModel eSRBRating = new ESRBRatingModel();

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

            List<ShortScreenshotModel> shortScreenshots = game.Short_Screenshots?.Select(g => new ShortScreenshotModel()
            {
                Game = g.Game,
                Image = g.Image,
            }).ToList() ?? new List<ShortScreenshotModel>();

            if (game.Metacritic is null)
            {
                game.Metacritic = 0;
            }

            var newGame = new GamesModel()
            {
                Added_By_Status = game.Added_By_Status ?? new Domain.Entities.AddedByStatus.AddedByStatusModel(),
                Name = game.Name,
                Background_Image = game.Background_Image,
                ESRB_Rating = game.ESRB_Rating ?? eSRBRating,
                Short_Screenshots = shortScreenshots,
                Genres = game.Genres ?? new List<GenreModel>(),
                Platforms = game.Platforms ?? new List<PlatformModel>(),
                Ratings = game.Ratings ?? new List<RatingModel>(),
                Tags = game.Tags ?? new List<TagModel>(),
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
                Stores = game.Stores ?? new List<StoreModel>(),
                GamesToDevelopers = new List<Domain.Entities.GamesToDeveloper.GamesToDeveloperModel>()
                {
                    new Domain.Entities.GamesToDeveloper.GamesToDeveloperModel()
                    {
                        DeveloperId = (int)developer.Id,
                    }
                },
                GamesToGenres = new List<Domain.Entities.GamesToGenres.GamesToGenresModel>(),
                GamesToRatings = new List<Domain.Entities.GamesToRating.GamesToRatingModel>(),
                GamesToPlatfrorms = new List<Domain.Entities.GamesToPlatform.GamesToPlatfrormModel>(),
                GamesToStores = new List<Domain.Entities.GamesToStore.GamesToStoresModel>(),
                GamesToTags = new List<Domain.Entities.GamesToTags.GamesToTagsModel>(),
                GameToShortScreenshots = new List<Domain.Entities.GamesToScreenshots.GamesToScreenshotsModel>(),
            };

            return newGame;
        }

        private async Task<List<PlatformModel>> GetAndUpdateExistingPlatformsAsync(List<PlatformModel> platforms)
        {
            if(platforms is null)
            {
                platforms = new List<PlatformModel>();
            }

            var existingPlatforms = new List<PlatformModel>();
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
                    platform.Platform = new Domain.Entities.PlatformInfo.PlatformInfoModel()
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

        private async Task<List<GenreModel>> GetAndUpdateExistingGenresAsync(List<GenreModel> genres)
        {
            if(genres is null)
            {
                genres = new List<GenreModel>();
            }

            var notExistGenres = new List<GenreModel>();
            var existingPlatforms = new List<GenreModel>();
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
                    var newGenre = new GenreModel()
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

        private async Task<List<StoreModel>> GetAndUpdateExistingStoresAsync(List<StoreModel> stores)
        {
            if(stores is null)
            {
                stores = new List<StoreModel>();
            }
            var existingStores = new List<StoreModel>();
            var noteExistingStores = new List<StoreModel>();
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
                    noteExistingStores.Add(new StoreModel()
                    {
                        Store = new Domain.Entities.StoreInfo.StoreInfoModel()
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

        private async Task<List<RatingModel>> GetAndUpdateExistingRatingsAsync(List<RatingModel> ratings)
        {
            if(ratings is null)
            {
                ratings = new List<RatingModel>();
            }

            var notExistRatings = new List<RatingModel>();
            var existingRatings = new List<RatingModel>();
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
                    var rating = new RatingModel()
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

        private async Task<List<TagModel>> GetAndUpdateExistingTagsAsync(List<TagModel> tags)
        {
            if(tags is null)
            {
                tags = new List<TagModel>();
            }

            var notExistTags = new List<TagModel>();
            var existingTags = new List<TagModel>();
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
                    var tag1 = new TagModel()
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

        private async Task<ESRBRatingModel> GetAndUpdateExistingEsrbRatingAsync(ESRBRatingModel eSRBRating)
        {
            if(eSRBRating is null)
            {
                eSRBRating = new ESRBRatingModel()
                {
                    Name = "Non defined",
                    Slug = "non_def",
                };
            }
            var existingeSRBRating = new ESRBRatingModel();

            existingeSRBRating = await _shopContext.ESRBRatings
                     .FirstOrDefaultAsync(p => p.Name == eSRBRating.Name);

            if (existingeSRBRating == null)
            {
                if(eSRBRating != null)
                {
                    eSRBRating = new ESRBRatingModel()
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
