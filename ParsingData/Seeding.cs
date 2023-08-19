using Domain.Entities;
using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using Infrastructure.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData
{
    public class Seeding
    {
        public static GamesEntity Seed()
        {
            AddedByStatusEntity addedByStatusModel = new AddedByStatusEntity()
            {
                Beaten = 3020,
                Yet = 595,
                Owned = 8401,
                Toplay = 318,
                Dropped = 684,
                Playing = 111,
            };

            string backImg = "https://media.rawg.io/media/games/f87/f87457e8347484033cb34cde6101d08d.jpg";

            ESRBRatingEntity eSRBRating = new ESRBRatingEntity
            {
                Name = "Adults Only",
                Slug = "adults-only",
            };

            List<GenreEntity> genreModels = new List<GenreEntity>()
            {
                new GenreEntity()
                {
                    Name = "Shooter",
                    Slug = "shooter",
                },
                new GenreEntity()
                {
                    Name = "Action",
                    Slug = "action",
                },
            };

            int metacritic = 90;

            List<PlatformEntity> platforms = new List<PlatformEntity>()
            {
                new PlatformEntity
                {
                    Platform = new Domain.Entities.PlatformInfo.PlatformInfoEntity
                    {
                        Name = "PC",
                        Slug = "pc",
                    },
                    Released_At = "",
                },

                new PlatformEntity
                {
                    Platform = new Domain.Entities.PlatformInfo.PlatformInfoEntity
                    {
                        Name = "PlayStation 4",
                        Slug = "playstation4",
                    },
                    Released_At = "",
                },
            };

            int playTime = 90000;

            double Rating = 4.07;

            int ratingTop = 4;

            List<RatingEntity> ratings = new List<RatingEntity>()
            {
                new RatingEntity
                {
                    Title = "exceptional",
                    Percent = 52.99,
                    Count = 1677,
                },

                new RatingEntity
                {
                    Title = "recommended",
                    Percent = 36.43,
                    Count = 1153,
                },
            };

            int ratingCount = 1813;

            string released = "2010-02-09";

            int reviewsCount = 1827;

            int reviewTextCount = 8;

            List<ShortScreenshotEntity> shortScreenshots = new List<ShortScreenshotEntity>()
            {
                new ShortScreenshotEntity
                {
                    Image = "https://media.rawg.io/media/games/bc0/bc06a29ceac58652b684deefe7d56099.jpg",
                },

                new ShortScreenshotEntity
                {
                    Image = "https://media.rawg.io/media/screenshots/01f/01f62d7064838a5c3202acfc61503487.jpg",
                },
            };

            string Slug = "the-darkness-ii";

            List<StoreEntity> stores = new List<StoreEntity>()
            {
                new StoreEntity
                {
                    Store = new Domain.Entities.StoreInfo.StoreInfoEntity
                    {
                        Name = "Steam",
                        Slug = "steam",
                    },
                },

                new StoreEntity
                {
                    Store = new Domain.Entities.StoreInfo.StoreInfoEntity
                    {
                        Slug = "playstation-store",
                        Name = "PlayStation Store",
                    },
                },
            };

            int suggestionCount = 673;

            string Updated = "2023-07-29T19:12:58";

            List<TagEntity> tags = new List<TagEntity>()
            {
                new TagEntity
                {
                    Name = "Singleplayer",
                    Slug = "singleplayer",
                    Language = "eng",
                    Games_Count = 207277,
                    Image_Background = "https://media.rawg.io/media/games/021/021c4e21a1824d2526f925eff6324653.jpg",
                },

                new TagEntity
                {
                    Name = "Для одного игрока",
                    Slug = "dlia-odnogo-igroka",
                    Language = "rus",
                    Games_Count = 35767,
                    Image_Background = "https://media.rawg.io/media/games/960/960b601d9541cec776c5fa42a00bf6c4.jpg",
                },
            };

            return new GamesEntity()
            {
                Background_Image = backImg,
                Added_By_Status = addedByStatusModel,
                ESRB_Rating = eSRBRating,
                Genres = genreModels,
                Metacritic = metacritic,
                Name = "Warframe",
                Platforms = platforms,
                Playtime = playTime,
                Rating = Rating,
                Rating_Top = ratingTop,
                Ratings = ratings,
                Ratings_Count = ratingCount,
                Released = released,
                Reviews_Count = reviewsCount,
                Reviews_Text_Count = reviewTextCount,
                Short_Screenshots = shortScreenshots,
                Slug = Slug,
                Stores = stores,
                Suggestions_Count = suggestionCount,
                Tba = false,
                Updated = Updated,
                Tags = tags,
                Developer = new List<DevelopersEntity>() { SeedDev() },
                GamesToDevelopers = new List<GamesToDeveloperEntity>()
                {
                    new Domain.Entities.GamesToDeveloper.GamesToDeveloperEntity()
                    {
                        Developer = SeedDev(),
                    }
                },
                GamesToGenres = new List<GamesToGenresEntity>()
                {
                    new Domain.Entities.GamesToGenres.GamesToGenresEntity()
                    {
                        Genre = genreModels[0],
                    }
                },
                GamesToPlatfrorms = new List<GamesToPlatfrormEntity>()
                {
                    new Domain.Entities.GamesToPlatform.GamesToPlatfrormEntity()
                    {
                        Platform = platforms[0],
                    }
                },
                GamesToRatings = new List<GamesToRatingEntity>()
                {
                    new Domain.Entities.GamesToRating.GamesToRatingEntity()
                    {
                        Rating = ratings[0],
                    }
                },
                GamesToStores = new List<GamesToStoresEntity>()
                {
                    new Domain.Entities.GamesToStore.GamesToStoresEntity()
                    {
                        Store = stores[0],
                    }
                },
                GamesToTags = new List<GamesToTagsEntity>()
                {
                    new Domain.Entities.GamesToTags.GamesToTagsEntity()
                    {
                        Tag = tags[0],
                    }
                },
                GameToShortScreenshots = new List<GamesToScreenshotsEntity>()
                {
                    new Domain.Entities.GamesToScreenshots.GamesToScreenshotsEntity()
                    {
                        ShortScreenshot = shortScreenshots[0],
                    }
                },
                GameKeys = SeedGameKeys(),
                Price = 60.00m,
            };
        }

        public static DevelopersEntity SeedDev()
        {
            return new DevelopersEntity()
            {
                Name = "Ubisoft",
                Slug = "ubisoft",
            };
        }

        public static List<GameKeyEntity> SeedGameKeys()
        {
            return new List<GameKeyEntity>
            {
                new GameKeyEntity()
                {
                    Key = Guid.NewGuid(),
                },
                new GameKeyEntity()
                {
                    Key = Guid.NewGuid(),
                },
                new GameKeyEntity()
                {
                    Key = Guid.NewGuid(),
                },
                new GameKeyEntity()
                {
                    Key = Guid.NewGuid(),
                },
                new GameKeyEntity()
                {
                    Key = Guid.NewGuid(),
                },
            };
        }
    }
}
