using Infrastructure.Models.Games;
using Infrastructure.Models.ShortScreenshot;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.GamesToScreenshots
{
    [Table("GamesToScreenshots")]
    public class GamesToScreenshotsModel
    {
        public int? GameId { get; set; }

        public int? ScreenshotId { get; set; }

        public GamesModel Game { get; set; }

        public ShortScreenshotModel ShortScreenshot { get; set; }
    }
}
