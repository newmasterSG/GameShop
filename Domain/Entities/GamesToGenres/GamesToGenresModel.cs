using Domain.Entities.Games;
using Domain.Entities.Genres;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.GamesToGenres
{
    public class GamesToGenresModel
    {
        public int? GameId { get; set; }

        public int? GenreId { get; set; }

        public GamesModel Game { get; set; }

        public GenreModel Genre { get; set; }
    }
}
