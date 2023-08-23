using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GamesToGenresEntity
    {
        public int? GameId { get; set; }

        public int? GenreId { get; set; }

        public GamesEntity Game { get; set; }

        public GenreEntity Genre { get; set; }
    }
}
