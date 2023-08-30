using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GamesEntity : EntityBase
    {
        public AddedByStatusEntity AddedByStatus { get; set; }
        public decimal Price { get; set; }
        public string? BackgroundImage { get; set; }
        public ESRBRatingEntity ESRBRating { get; set; }
        public List<GenreEntity> Genres { get; set; }
        public new int? Id { get; set; }
        public int? Metacritic { get; set; }
        public string? Name { get; set; }
        public List<PlatformEntity> Platforms { get; set; }
        public int? Playtime { get; set; }
        public double? Rating { get; set; }
        public int? RatingTop { get; set; }
        public List<RatingEntity> Ratings { get; set; }
        public int? Ratings_Count { get; set; }
        public string? Released { get; set; }
        public int? ReviewsCount { get; set; }
        public int? ReviewsTextCount { get; set; }
        public List<ShortScreenshotEntity> ShortScreenshots { get; set; }
        public string? Slug { get; set; }
        public List<StoreEntity> Stores { get; set; }
        public int? SuggestionsCount { get; set; }
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

        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
