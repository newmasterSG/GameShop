using Domain.Models.Games;
using Domain.Models.GamesToESRBRating;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.ESRBRating
{
    [Table("ESRBRating")]
    public class ESRBRatingModel: EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToESRBRatingModel> GamesToESRBRating { get; set; }
    }
}
