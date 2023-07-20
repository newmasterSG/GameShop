using DomainLayer.Models.AddedByStatus;
using DomainLayer.Models.ESRBRating;
using DomainLayer.Models.GamesToAddedByStatus;
using DomainLayer.Models.GamesToGenres;
using DomainLayer.Models.GamesToPlatform;
using DomainLayer.Models.GamesToTags;
using DomainLayer.Models.Genres;
using DomainLayer.Models.Platform;
using DomainLayer.Models.Rating;
using DomainLayer.Models.ShortScreenshot;
using DomainLayer.Models.Store;
using DomainLayer.Models.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Games
{
    [Table("Game")]
    public class GamesModel 
    {
        public AddedByStatusModel Added_By_Status { get; set; }
        public string Background_Image { get; set; }
        public string Dominant_Color { get; set; }
        public ESRBRatingModel ESRB_Rating { get; set; }
        public List<GenreModel> Genres { get; set; }
        public int Id { get; set; }
        public int Metacritic { get; set; }
        public string Name { get; set; }
        public List<PlatformModel> Parent_Platforms { get; set; }
        public List<PlatformModel> Platforms { get; set; }
        public int Playtime { get; set; }
        public double Rating { get; set; }
        public int Rating_Top { get; set; }
        public List<RatingModel> Ratings { get; set; }
        public int Ratings_Count { get; set; }
        public string Released { get; set; }
        public int Reviews_Count { get; set; }
        public int Reviews_Text_Count { get; set; }
        public string Saturated_Color { get; set; }
        public List<ShortScreenshotModel> Short_Screenshots { get; set; }
        public string Slug { get; set; }
        public List<StoreModel> Stores { get; set; }
        public int Suggestions_Count { get; set; }
        public List<TagModel> Tags { get; set; }
        public bool Tba { get; set; }
        public string Updated { get; set; }
        public object UserGame { get; set; }

        public List<GamesToTagsModel> GamesToTags { get; set; }

        public List<GamesToGenresModel> GamesToGenres { get; set; }

        public List<GamesToPlatfrormModel> GamesToPlatfrorms { get; set; }

        public GamesToAddedByStatusModel GamesToAddedByStatuses { get; set; }
    }
}
