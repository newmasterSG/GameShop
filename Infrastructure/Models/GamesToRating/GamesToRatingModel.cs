using Infrastructure.Models.Games;
using Infrastructure.Models.Rating;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.GamesToRating
{
    [Table("GamesToRating")]
    public class GamesToRatingModel
    {
        public int GameId { get; set; }

        public int RatingId { get; set; }

        public GamesModel Game { get; set; }

        public RatingModel Rating { get; set; }
    }
}
