using Domain.Entities.AddedByStatus;
using Domain.Entities.Developer;
using Domain.Entities.ESRBRating;
using Domain.Entities.Games;
using Domain.Entities.Genres;
using Domain.Entities.Platform;
using Domain.Entities.Rating;
using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using Domain.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData
{
    public class Seeding
    {
        public static GamesModel Seed()
        {
            AddedByStatusModel addedByStatusModel = new AddedByStatusModel()
            {
                Beaten = 3020,
                Yet = 595,
                Owned = 8401,
                Toplay = 318,
                Dropped = 684,
                Playing = 111,
            };

            string backImg = "https://media.rawg.io/media/games/f87/f87457e8347484033cb34cde6101d08d.jpg";

            ESRBRatingModel eSRBRating = new ESRBRatingModel
            {
                Name = "Adults Only",
                Slug = "adults-only",
            };

            List<GenreModel> genreModels = new List<GenreModel>()
            {
                new GenreModel()
                {
                    Name = "Shooter",
                    Slug = "shooter",
                },
                new GenreModel()
                {
                    Name = "Action",
                    Slug = "action",
                },
            };

            int metacritic = 90;

            List<PlatformModel> platforms = new List<PlatformModel>()
            {
                new PlatformModel
                {
                    Platform = new Domain.Entities.PlatformInfo.PlatformInfoModel
                    {
                        Name = "PC",
                        Slug = "pc",
                    },
                    Released_At = "",
                },

                new PlatformModel
                {
                    Platform = new Domain.Entities.PlatformInfo.PlatformInfoModel
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

            List<RatingModel> ratings = new List<RatingModel>()
            {
                new RatingModel
                {
                    Title = "exceptional",
                    Percent = 52.99,
                    Count = 1677,
                },

                new RatingModel
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

            List<ShortScreenshotModel> shortScreenshots = new List<ShortScreenshotModel>()
            {
                new ShortScreenshotModel
                {
                    Image = "https://media.rawg.io/media/games/bc0/bc06a29ceac58652b684deefe7d56099.jpg",
                },

                new ShortScreenshotModel
                {
                    Image = "https://media.rawg.io/media/screenshots/01f/01f62d7064838a5c3202acfc61503487.jpg",
                },
            };

            string Slug = "the-darkness-ii";

            List<StoreModel> stores = new List<StoreModel>()
            {
                new StoreModel
                {
                    Store = new Domain.Entities.StoreInfo.StoreInfoModel
                    {
                        Name = "Steam",
                        Slug = "steam",
                    },
                },

                new StoreModel
                {
                    Store = new Domain.Entities.StoreInfo.StoreInfoModel
                    {
                        Slug = "playstation-store",
                        Name = "PlayStation Store",
                    },
                },
            };

            int suggestionCount = 673;

            string Updated = "2023-07-29T19:12:58";

            List<TagModel> tags = new List<TagModel>()
            {
                new TagModel
                {
                    Name = "Singleplayer",
                    Slug = "singleplayer",
                    Language = "eng",
                    Games_Count = 207277,
                    Image_Background = "https://media.rawg.io/media/games/021/021c4e21a1824d2526f925eff6324653.jpg",
                },

                new TagModel
                {
                    Name = "Для одного игрока",
                    Slug = "dlia-odnogo-igroka",
                    Language = "rus",
                    Games_Count = 35767,
                    Image_Background = "https://media.rawg.io/media/games/960/960b601d9541cec776c5fa42a00bf6c4.jpg",
                },
            };

            return new GamesModel()
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
            };
        }

        public static DevelopersModel SeedDev()
        {
            return new DevelopersModel()
            {
                Name = "Ubisoft",
                Slug = "ubisoft",
            };
        }
    }
}
