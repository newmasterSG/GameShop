using Domain.Models.AddedByStatus;
using Domain.Models.Developer;
using Domain.Models.ESRBRating;
using Domain.Models.GamesToAddedByStatus;
using Domain.Models.GamesToESRBRating;
using Domain.Models.GamesToGenres;
using Domain.Models.GamesToPlatform;
using Domain.Models.GamesToRating;
using Domain.Models.GamesToScreenshots;
using Domain.Models.GamesToStore;
using Domain.Models.GamesToTags;
using Domain.Models.Genres;
using Domain.Models.Platform;
using Domain.Models.Rating;
using Domain.Models.ShortScreenshot;
using Domain.Models.Store;
using Domain.Models.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Games
{
    [Table("Game")]
    public class GamesModel : EntityBase
    {
        public AddedByStatusModel Added_By_Status { get; set; }
        public string? Background_Image { get; set; }
        public ESRBRatingModel ESRB_Rating { get; set; }
        public List<GenreModel> Genres { get; set; }
        public new int? Id { get; set; }
        public int? Metacritic { get; set; }
        public string? Name { get; set; }
        public List<PlatformModel> Platforms { get; set; }
        public int? Playtime { get; set; }
        public double? Rating { get; set; }
        public int? Rating_Top { get; set; }
        public List<RatingModel> Ratings { get; set; }
        public int? Ratings_Count { get; set; }
        public string? Released { get; set; }
        public int? Reviews_Count { get; set; }
        public int? Reviews_Text_Count { get; set; }
        public List<ShortScreenshotModel> Short_Screenshots { get; set; }
        public string? Slug { get; set; }
        public List<StoreModel> Stores { get; set; }
        public int? Suggestions_Count { get; set; }
        public List<TagModel> Tags { get; set; }
        public bool? Tba { get; set; }
        public string? Updated { get; set; }

        public int DeveloperId { get; set; }
        public DevelopersModel Developer { get; set; }

        public List<GamesToTagsModel> GamesToTags { get; set; }

        public List<GamesToGenresModel> GamesToGenres { get; set; }

        public List<GamesToPlatfrormModel> GamesToPlatfrorms { get; set; }

        public GamesToAddedByStatusModel GamesToAddedByStatuses { get; set; }

        public GamesToESRBRatingModel GamesToESRBRating { get; set; }

        public List<GamesToRatingModel> GamesToRatings { get;set; }

        public List<GamesToScreenshotsModel> GameToShortScreenshots { get; set; }

        public List<GamesToStoresModel> GamesToStores { get; set; }
    }
}
