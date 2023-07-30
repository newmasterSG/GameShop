using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToRating;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Rating
{
    [Table("Rating")]
    public class RatingModel: EntityBase
    {
        public new int? Id { get; set; }
        public string? Title { get; set; }
        public int? Count { get; set; }
        public double? Percent { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToRatingModel> GamesToRatings { get; set; }
    }
}
