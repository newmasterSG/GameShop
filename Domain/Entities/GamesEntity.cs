using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GamesEntity : EntityBase
    {
        public AddedByStatusEntity Added_By_Status { get; set; }
        public decimal Price { get; set; }
        public string? Background_Image { get; set; }
        public ESRBRatingEntity ESRB_Rating { get; set; }
        public List<GenreEntity> Genres { get; set; }
        public new int? Id { get; set; }
        public int? Metacritic { get; set; }
        public string? Name { get; set; }
        public List<PlatformEntity> Platforms { get; set; }
        public int? Playtime { get; set; }
        public double? Rating { get; set; }
        public int? Rating_Top { get; set; }
        public List<RatingEntity> Ratings { get; set; }
        public int? Ratings_Count { get; set; }
        public string? Released { get; set; }
        public int? Reviews_Count { get; set; }
        public int? Reviews_Text_Count { get; set; }
        public List<ShortScreenshotEntity> Short_Screenshots { get; set; }
        public string? Slug { get; set; }
        public List<StoreEntity> Stores { get; set; }
        public int? Suggestions_Count { get; set; }
        public List<TagEntity> Tags { get; set; }
        public bool? Tba { get; set; }
        public string? Updated { get; set; }

        public List<DevelopersEntity> Developer { get; set; }
        public List<GamesToTagsEntity> GamesToTags { get; set; }

        public List<GamesToGenresEntity> GamesToGenres { get; set; }

        public List<GamesToPlatfrormEntity> GamesToPlatfrorms { get; set; }

        public List<GamesToRatingEntity> GamesToRatings { get; set; }

        public List<GamesToScreenshotsEntity> GameToShortScreenshots { get; set; }

        public List<GamesToStoresEntity> GamesToStores { get; set; }

        public List<GamesToDeveloperEntity> GamesToDevelopers { get; set; }
        public List<GameKeyEntity> GameKeys { get; set; }
        public List<OrderGameEntity> OrderedGames { get; set; }
        public List<OrderEntity> Orders { get; set; }
    }
}
