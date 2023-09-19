using Domain.Entities;

namespace UI.Seedings
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
                    Platform = new Domain.Entities.PlatformInfoEntity
                    {
                        Name = "PC",
                        Slug = "pc",
                    },
                    ReleasedAt = "",
                },

                new PlatformEntity
                {
                    Platform = new Domain.Entities.PlatformInfoEntity
                    {
                        Name = "PlayStation 4",
                        Slug = "playstation4",
                    },
                    ReleasedAt = "",
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
                    Store = new Domain.Entities.StoreInfoEntity
                    {
                        Name = "Steam",
                        Slug = "steam",
                    },
                },

                new StoreEntity
                {
                    Store = new Domain.Entities.StoreInfoEntity
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
                    GamesCount = 207277,
                    ImageBackground = "https://media.rawg.io/media/games/021/021c4e21a1824d2526f925eff6324653.jpg",
                },

                new TagEntity
                {
                    Name = "Для одного игрока",
                    Slug = "dlia-odnogo-igroka",
                    Language = "rus",
                    GamesCount = 35767,
                    ImageBackground = "https://media.rawg.io/media/games/960/960b601d9541cec776c5fa42a00bf6c4.jpg",
                },
            };

            return new GamesEntity()
            {
                BackgroundImage = backImg,
                AddedByStatus = addedByStatusModel,
                ESRBRating = eSRBRating,
                Genres = genreModels,
                Metacritic = metacritic,
                Name = "Warframe",
                Platforms = platforms,
                Playtime = playTime,
                Rating = Rating,
                RatingTop = ratingTop,
                Ratings = ratings,
                Ratings_Count = ratingCount,
                Released = released,
                ReviewsCount = reviewsCount,
                ReviewsTextCount = reviewTextCount,
                ShortScreenshots = shortScreenshots,
                Slug = Slug,
                Stores = stores,
                SuggestionsCount = suggestionCount,
                Tba = false,
                Updated = Updated,
                Tags = tags,
                Developer = new List<DevelopersEntity>() { SeedDev() },
                GamesToDevelopers = new List<GamesToDeveloperEntity>()
                {
                    new Domain.Entities.GamesToDeveloperEntity()
                    {
                        Developer = SeedDev(),
                    }
                },
                GamesToGenres = new List<GamesToGenresEntity>()
                {
                    new Domain.Entities.GamesToGenresEntity()
                    {
                        Genre = genreModels[0],
                    }
                },
                GamesToPlatfrorms = new List<GamesToPlatfrormEntity>()
                {
                    new Domain.Entities.GamesToPlatfrormEntity()
                    {
                        Platform = platforms[0],
                    }
                },
                GamesToRatings = new List<GamesToRatingEntity>()
                {
                    new Domain.Entities.GamesToRatingEntity()
                    {
                        Rating = ratings[0],
                    }
                },
                GamesToStores = new List<GamesToStoresEntity>()
                {
                    new Domain.Entities.GamesToStoresEntity()
                    {
                        Store = stores[0],
                    }
                },
                GamesToTags = new List<GamesToTagsEntity>()
                {
                    new Domain.Entities.GamesToTagsEntity()
                    {
                        Tag = tags[0],
                    }
                },
                GameToShortScreenshots = new List<GamesToScreenshotsEntity>()
                {
                    new Domain.Entities.GamesToScreenshotsEntity()
                    {
                        ShortScreenshot = shortScreenshots[0],
                    }
                },
                GameKeys = SeedGameKeys(),
                Price = 60.00m,
            };
        }

        public static List<GamesEntity> SeedGames()
        {
            List<GamesEntity> games = new List<GamesEntity>();

            for (int i = 0; i < 10; i++)
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
                    Name = "Mature",
                    Slug = "mature",
                };

                List<GenreEntity> genreModels = new List<GenreEntity>()
        {
            new GenreEntity()
            {
                Name = "RPG",
                Slug = "rpg",
            },
            new GenreEntity()
            {
                Name = "Adventure",
                Slug = "adventure",
            },
        };

                int metacritic = 85;

                List<PlatformEntity> platforms = new List<PlatformEntity>()
        {
            new PlatformEntity
            {
                Platform = new Domain.Entities.PlatformInfoEntity
                {
                    Name = "Xbox One",
                    Slug = "xbox-one",
                },
                ReleasedAt = "",
            },

            new PlatformEntity
            {
                Platform = new Domain.Entities.PlatformInfoEntity
                {
                    Name = "Nintendo Switch",
                    Slug = "nintendo-switch",
                },
                ReleasedAt = "",
            },
        };

                int playTime = 60000;

                double Rating = 4.5;

                int ratingTop = 5;

                List<RatingEntity> ratings = new List<RatingEntity>()
        {
            new RatingEntity
            {
                Title = "outstanding",
                Percent = 60.0,
                Count = 2500,
            },

            new RatingEntity
            {
                Title = "excellent",
                Percent = 35.0,
                Count = 1800,
            },
        };

                int ratingCount = 4300;

                string released = "2015-08-17";

                int reviewsCount = 3500;

                int reviewTextCount = 10;

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

                string Slug = $"game-{i + 1}";

                List<StoreEntity> stores = new List<StoreEntity>()
        {
            new StoreEntity
            {
                Store = new Domain.Entities.StoreInfoEntity
                {
                    Name = "Store 1",
                    Slug = "store-1",
                },
            },

            new StoreEntity
            {
                Store = new Domain.Entities.StoreInfoEntity
                {
                    Slug = "store-2",
                    Name = "Store 2",
                },
            },
        };

                int suggestionCount = 1200;

                string Updated = "2023-09-14T10:30:00";

                List<TagEntity> tags = new List<TagEntity>()
        {
            new TagEntity
            {
                Name = "Tag 1",
                Slug = "tag-1",
                Language = "eng",
                GamesCount = 15000,
                ImageBackground = "https://media.rawg.io/media/games/021/021c4e21a1824d2526f925eff6324653.jpg",
            },

            new TagEntity
            {
                Name = "Tag 2",
                Slug = "tag-2",
                Language = "rus",
                GamesCount = 8000,
                ImageBackground = "https://media.rawg.io/media/games/960/960b601d9541cec776c5fa42a00bf6c4.jpg",
            },
        };

                games.Add(new GamesEntity()
                {
                    BackgroundImage = backImg,
                    AddedByStatus = addedByStatusModel,
                    ESRBRating = eSRBRating,
                    Genres = genreModels,
                    Metacritic = metacritic,
                    Name = $"Game {i + 1}",
                    Platforms = platforms,
                    Playtime = playTime,
                    Rating = Rating,
                    RatingTop = ratingTop,
                    Ratings = ratings,
                    Ratings_Count = ratingCount,
                    Released = released,
                    ReviewsCount = reviewsCount,
                    ReviewsTextCount = reviewTextCount,
                    ShortScreenshots = shortScreenshots,
                    Slug = Slug,
                    Stores = stores,
                    SuggestionsCount = suggestionCount,
                    Tba = false,
                    Updated = Updated,
                    Tags = tags,
                    Developer = new List<DevelopersEntity>() { SeedDev() },
                    GamesToDevelopers = new List<GamesToDeveloperEntity>()
            {
                new Domain.Entities.GamesToDeveloperEntity()
                {
                    Developer = SeedDev(),
                }
            },
                    GamesToGenres = new List<GamesToGenresEntity>()
            {
                new Domain.Entities.GamesToGenresEntity()
                {
                    Genre = genreModels[0],
                }
            },
                    GamesToPlatfrorms = new List<GamesToPlatfrormEntity>()
            {
                new Domain.Entities.GamesToPlatfrormEntity()
                {
                    Platform = platforms[0],
                }
            },
                    GamesToRatings = new List<GamesToRatingEntity>()
            {
                new Domain.Entities.GamesToRatingEntity()
                {
                    Rating = ratings[0],
                }
            },
                    GamesToStores = new List<GamesToStoresEntity>()
            {
                new Domain.Entities.GamesToStoresEntity()
                {
                    Store = stores[0],
                }
            },
                    GamesToTags = new List<GamesToTagsEntity>()
            {
                new Domain.Entities.GamesToTagsEntity()
                {
                    Tag = tags[0],
                }
            },
                    GameToShortScreenshots = new List<GamesToScreenshotsEntity>()
            {
                new Domain.Entities.GamesToScreenshotsEntity()
                {
                    ShortScreenshot = shortScreenshots[0],
                }
            },
                    GameKeys = SeedGameKeys(),
                    Price = 49.99m,
                });
            }

            return games;
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
