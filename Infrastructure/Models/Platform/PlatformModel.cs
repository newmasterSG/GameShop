using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToPlatform;
using Infrastructure.Models.PlatformInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Platform
{
    [Table("Platform")]
    public class PlatformModel : EntityBase
    {
        public new int? Id { get; set; }
        public PlatformInfoModel Platform { get; set; }

        public string? Released_At { get; set; }
        [NotMapped]
        public object Requirements_En { get; set; }
        [NotMapped]
        public object Requirements_Ru { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToPlatfrormModel> GamesToPlatfrorms { get; set; }
    }
}
