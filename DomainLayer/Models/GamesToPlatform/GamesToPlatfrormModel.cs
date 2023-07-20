using DomainLayer.Models.Games;
using DomainLayer.Models.Platform;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.GamesToPlatform
{
    [Table("GamesToPlatfrorm")]
    public class GamesToPlatfrormModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int PlatformId { get; set; }

        public GamesModel Game { get; set; }

        public PlatformModel Platform { get; set; }
    }
}
