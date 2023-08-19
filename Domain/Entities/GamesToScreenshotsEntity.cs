using Domain.Entities.ShortScreenshot;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GamesToScreenshotsEntity
    {
        public int? GameId { get; set; }

        public int? ScreenshotId { get; set; }

        public GamesEntity Game { get; set; }

        public ShortScreenshotEntity ShortScreenshot { get; set; }
    }
}
