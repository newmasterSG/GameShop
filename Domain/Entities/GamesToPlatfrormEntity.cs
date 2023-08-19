using Domain.Entities.Platform;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GamesToPlatfrormEntity
    {
        public int? GameId { get; set; }

        public int? PlatformId { get; set; }

        public GamesEntity Game { get; set; }

        public PlatformEntity Platform { get; set; }
    }
}
