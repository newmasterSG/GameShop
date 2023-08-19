using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ShortScreenshot
{
    public class ShortScreenshotEntity : EntityBase
    {
        public new int? Id { get; set; }
        public string? Image { get; set; }
        public GamesEntity Game { get; set; }

        public GamesToScreenshotsEntity GamesToScreenshots { get; set; }
    }
}
