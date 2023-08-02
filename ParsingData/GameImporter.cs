using Infrastructure.Context;
using Infrastructure.Models.Developer;
using Infrastructure.Models.ESRBRating;
using Infrastructure.Models.Games;
using Infrastructure.Models.Genres;
using Infrastructure.Models.Platform;
using Infrastructure.Models.Rating;
using Infrastructure.Models.ShortScreenshot;
using Infrastructure.Models.Store;
using Infrastructure.Models.Tags;
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

            List<GenreModel> genres = game.Genres?.Select(item => new GenreModel()
            {
                Slug = item.Slug,
                Name = item.Name,
                Image_Background = item.Image_Background,
                Games = item.Games,
                GamesCount = item.GamesCount,
            }).ToList() ?? new List<GenreModel>();

            List<PlatformModel> platforms = game.Platforms?.Select(pl => new PlatformModel()
                {
                    Games = pl.Games,
                    Platform = new Infrastructure.Models.PlatformInfo.PlatformInfoModel()
                    {
                        Games_Count = pl.Platform.Games_Count,
                        Name = pl.Platform.Name,
                        Slug = pl.Platform.Slug,
                        Image = pl.Platform.Image,
                        Year_End = pl.Platform.Year_End,
                        Year_start = pl.Platform.Year_start,
                        Image_Background = pl.Platform.Image_Background,
                    },
                    Released_At = pl.Released_At,
                    Requirements_En = pl.Requirements_En,
                    Requirements_Ru = pl.Requirements_Ru,
                }).ToList() ?? new List<PlatformModel>();

            List<RatingModel> ratings = game.Ratings?.Select(r => new RatingModel()
            {
                Count = r.Count,
                Games = r.Games,
                Title = r.Title,
                Percent = r.Percent,
            }).ToList() ?? new List<RatingModel>();

            List<TagModel> tags = game.Tags?.Select(t => new TagModel()
            {
                Name = t.Name,
                Slug = t.Slug,
                Language = t.Language,
                Games_Count = t.Games_Count,
                Image_Background = t.Image_Background,
            }).ToList() ?? new List<TagModel>();

            List<ShortScreenshotModel> shortScreenshots = game.Short_Screenshots.Select(g => new ShortScreenshotModel()
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
                Added_By_Status = game.Added_By_Status,
                Name = game.Name,
                Background_Image = game.Background_Image,
                ESRB_Rating = game.ESRB_Rating ?? eSRBRating,
                Short_Screenshots = shortScreenshots,
                Genres = game.Genres ?? genres,
                Platforms = game.Platforms ?? platforms,
                Ratings = game.Ratings ?? ratings,
                Tags = game.Tags ?? tags,
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
                DeveloperId = (int)developer.Id,
                Stores = game.Stores ?? new List<StoreModel>(),
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
                    platform.Platform = new Infrastructure.Models.PlatformInfo.PlatformInfoModel()
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
                        Store = new Infrastructure.Models.StoreInfo.StoreInfoModel()
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
