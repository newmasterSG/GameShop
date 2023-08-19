using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Rating
{
    public class RatingEntity: EntityBase
    {
        public new int? Id { get; set; }
        public string? Title { get; set; }
        public int? Count { get; set; }
        public double? Percent { get; set; }

        public List<GamesEntity> Games { get; set; }

        public List<GamesToRatingEntity> GamesToRatings { get; set; }
    }
}
