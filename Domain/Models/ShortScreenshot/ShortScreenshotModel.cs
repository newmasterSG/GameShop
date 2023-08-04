using Domain.Models.Games;
using Domain.Models.GamesToScreenshots;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.ShortScreenshot
{
    [Table("ShortScreenshot")]
    public class ShortScreenshotModel : EntityBase
    {
        public new int? Id { get; set; }
        public string? Image { get; set; }
        public GamesModel Game { get; set; }

        public GamesToScreenshotsModel GamesToScreenshots { get; set; }
    }
}
