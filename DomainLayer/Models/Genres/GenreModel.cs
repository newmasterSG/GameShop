using DomainLayer.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Genres
{
    [Table("Genre")]
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int GamesCount { get; set; }
        public string ImageBackground { get; set; }

        public List<GamesModel> Games { get; set; }
    }
}
