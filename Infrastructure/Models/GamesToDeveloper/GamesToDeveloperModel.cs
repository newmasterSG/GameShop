using Infrastructure.Models.Developer;
using Infrastructure.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.GamesToDeveloper
{
    [Table("GamesToDeveloper")]
    public class GamesToDeveloperModel
    {
        public int GameId { get; set; }

        public int DeveloperId { get; set; }

        public GamesModel Game { get; set; }

        public DevelopersModel Developer { get; set; }
    }
}
