using Domain.Models.ESRBRating;
using Domain.Models.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.GamesToESRBRating
{
    [Table("GamesToESRBRating")]
    public class GamesToESRBRatingModel
    {
        public int? GameId { get; set; }

        public int? ESRBId { get; set; }

        public ESRBRatingModel ESRBRatingModel { get; set; }

        public GamesModel Game { get; set;}
    }
}
