using DomainLayer.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Rating
{
    [Table("Rating")]
    public class RatingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public double Percent { get; set; }

        public List<GamesModel> Games { get; set; }
    }
}
