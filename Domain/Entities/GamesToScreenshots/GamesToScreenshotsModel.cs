using Domain.Entities.Games;
using Domain.Entities.ShortScreenshot;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.GamesToScreenshots
{
    public class GamesToScreenshotsModel
    {
        public int? GameId { get; set; }

        public int? ScreenshotId { get; set; }

        public GamesModel Game { get; set; }

        public ShortScreenshotModel ShortScreenshot { get; set; }
    }
}
