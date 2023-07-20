using DomainLayer.Models.Games;
using DomainLayer.Models.GamesToPlatform;
using DomainLayer.Models.PlatformInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Platform
{
    [Table("Platform")]
    public class PlatformModel
    {
        public PlatformInfoModel Platform { get; set; }
        public string Released_At { get; set; }
        public object Requirements_En { get; set; }
        public object Requirements_Ru { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToPlatfrormModel> GamesToPlatfrorms { get; set; }
    }
}
