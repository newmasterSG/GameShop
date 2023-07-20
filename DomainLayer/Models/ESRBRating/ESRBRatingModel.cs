using DomainLayer.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.ESRBRating
{
    [Table("ESRBRating")]
    public class ESRBRatingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<GamesModel> Games { get; set; }
    }
}
