using Infrastructure.Models.Games;
using Infrastructure.Models.Platform;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.GamesToPlatform
{
    [Table("GamesToPlatfrorm")]
    public class GamesToPlatfrormModel
    {
        public int GameId { get; set; }

        public int PlatformId { get; set; }

        public GamesModel Game { get; set; }

        public PlatformModel Platform { get; set; }
    }
}
