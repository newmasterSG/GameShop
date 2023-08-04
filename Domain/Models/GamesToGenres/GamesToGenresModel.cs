using Domain.Models.Games;
using Domain.Models.Genres;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.GamesToGenres
{
    [Table("GamesToGenres")]
    public class GamesToGenresModel
    {
        public int? GameId { get; set; }

        public int? GenreId { get; set; }

        public GamesModel Game { get; set; }

        public GenreModel Genre { get; set; }
    }
}
