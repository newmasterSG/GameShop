using Domain.Entities.Games;
using Domain.Entities.GamesToESRBRating;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ESRBRating
{
    public class ESRBRatingModel: EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToESRBRatingModel> GamesToESRBRating { get; set; }
    }
}
