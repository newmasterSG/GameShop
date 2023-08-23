using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GamesToRatingEntity
    {
        public int? GameId { get; set; }

        public int? RatingId { get; set; }

        public GamesEntity Game { get; set; }

        public RatingEntity Rating { get; set; }
    }
}
