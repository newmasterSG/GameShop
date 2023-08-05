using Domain.Entities.AddedByStatus;
using Domain.Entities.Developer;
using Domain.Entities.ESRBRating;
using Domain.Entities.GamesToAddedByStatus;
using Domain.Entities.GamesToDeveloper;
using Domain.Entities.GamesToESRBRating;
using Domain.Entities.GamesToGenres;
using Domain.Entities.GamesToPlatform;
using Domain.Entities.GamesToRating;
using Domain.Entities.GamesToScreenshots;
using Domain.Entities.GamesToStore;
using Domain.Entities.GamesToTags;
using Domain.Entities.Genres;
using Domain.Entities.Platform;
using Domain.Entities.Rating;
using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using Domain.Entities.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Games
{
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

        public List<DevelopersModel> Developer { get; set; }
        public List<GamesToTagsModel> GamesToTags { get; set; }

        public List<GamesToGenresModel> GamesToGenres { get; set; }

        public List<GamesToPlatfrormModel> GamesToPlatfrorms { get; set; }

        public GamesToAddedByStatusModel GamesToAddedByStatuses { get; set; }

        public GamesToESRBRatingModel GamesToESRBRating { get; set; }

        public List<GamesToRatingModel> GamesToRatings { get;set; }

        public List<GamesToScreenshotsModel> GameToShortScreenshots { get; set; }

        public List<GamesToStoresModel> GamesToStores { get; set; }

        public List<GamesToDeveloperModel> GamesToDevelopers { get; set; }
    }
}
