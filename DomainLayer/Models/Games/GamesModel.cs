using DomainLayer.Models.AddedByStatus;
using DomainLayer.Models.ESRBRating;
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
        public AddedByStatusModel AddedByStatus { get; set; }
        public string BackgroundImage { get; set; }
        public string DominantColor { get; set; }
        public ESRBRatingModel ESRBRating { get; set; }
        public List<GenreModel> Genres { get; set; }
        public int Id { get; set; }
        public int Metacritic { get; set; }
        public string Name { get; set; }
        public List<PlatformModel> ParentPlatforms { get; set; }
        public List<PlatformModel> Platforms { get; set; }
        public int Playtime { get; set; }
        public double Rating { get; set; }
        public int RatingTop { get; set; }
        public List<RatingModel> Ratings { get; set; }
        public int RatingsCount { get; set; }
        public string Released { get; set; }
        public int ReviewsCount { get; set; }
        public int ReviewsTextCount { get; set; }
        public string SaturatedColor { get; set; }
        public List<ShortScreenshotModel> ShortScreenshots { get; set; }
        public string Slug { get; set; }
        public List<StoreModel> Stores { get; set; }
        public int SuggestionsCount { get; set; }
        public List<TagModel> Tags { get; set; }
        public bool Tba { get; set; }
        public string Updated { get; set; }
        public object UserGame { get; set; }
    }
}
