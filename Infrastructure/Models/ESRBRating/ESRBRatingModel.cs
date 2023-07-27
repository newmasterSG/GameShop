using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToESRBRating;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.ESRBRating
{
    [Table("ESRBRating")]
    public class ESRBRatingModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToESRBRatingModel> GamesToESRBRating { get; set; }
    }
}
