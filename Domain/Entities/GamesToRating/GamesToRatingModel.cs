using Domain.Entities.Games;
using Domain.Entities.Rating;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GamesToRating
{
    public class GamesToRatingModel
    {
        public int? GameId { get; set; }

        public int? RatingId { get; set; }

        public GamesModel Game { get; set; }

        public RatingModel Rating { get; set; }
    }
}
