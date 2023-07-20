using DomainLayer.Models.Games;
using DomainLayer.Models.PlatformInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Platform
{
    [Table("Platform")]
    public class PlatformModel
    {
        public PlatformInfoModel PlatformInfo { get; set; }
        public string ReleasedAt { get; set; }
        public object RequirementsEn { get; set; }
        public object RequirementsRu { get; set; }

        public List<GamesModel> Games { get; set; }
    }
}
