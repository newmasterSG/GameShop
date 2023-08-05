using Domain.Entities.Games;
using Domain.Entities.GamesToRating;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Rating
{
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
