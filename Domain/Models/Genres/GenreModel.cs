using Domain.Models.Games;
using Domain.Models.GamesToGenres;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Genres
{
    [Table("Genre")]
    public class GenreModel: EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public int? GamesCount { get; set; }
        public string? Image_Background { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToGenresModel> GamesToGenres { get; set; }
    }
}
