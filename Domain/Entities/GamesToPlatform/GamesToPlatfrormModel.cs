using Domain.Entities.Games;
using Domain.Entities.Platform;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.GamesToPlatform
{
    public class GamesToPlatfrormModel
    {
        public int? GameId { get; set; }

        public int? PlatformId { get; set; }

        public GamesModel Game { get; set; }

        public PlatformModel Platform { get; set; }
    }
}
