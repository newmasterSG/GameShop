using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PlatformEntity : EntityBase
    {
        public new int? Id { get; set; }
        public PlatformInfoEntity Platform { get; set; }

        public string? ReleasedAt { get; set; }

        public List<GamesEntity> Games { get; set; }

        public List<GamesToPlatfrormEntity> GamesToPlatfrorms { get; set; }
    }
}
