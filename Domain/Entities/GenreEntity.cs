using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GenreEntity : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public int? GamesCount { get; set; }
        public string? ImageBackground { get; set; }

        public List<GamesEntity> Games { get; set; }

        public List<GamesToGenresEntity> GamesToGenres { get; set; }
    }
}
