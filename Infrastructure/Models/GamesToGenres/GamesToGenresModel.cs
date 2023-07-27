using Infrastructure.Models.Games;
using Infrastructure.Models.Genres;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.GamesToGenres
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
