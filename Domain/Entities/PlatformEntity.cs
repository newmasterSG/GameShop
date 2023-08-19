using Domain.Entities.PlatformInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PlatformEntity : EntityBase
    {
        public new int? Id { get; set; }
        public PlatformInfoEntity Platform { get; set; }

        public string? Released_At { get; set; }
        [NotMapped]
        public object Requirements_En { get; set; }
        [NotMapped]
        public object Requirements_Ru { get; set; }

        public List<GamesEntity> Games { get; set; }

        public List<GamesToPlatfrormEntity> GamesToPlatfrorms { get; set; }
    }
}
