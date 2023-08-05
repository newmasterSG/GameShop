using Domain.Entities.Games;
using Domain.Entities.GamesToScreenshots;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ShortScreenshot
{
    public class ShortScreenshotModel : EntityBase
    {
        public new int? Id { get; set; }
        public string? Image { get; set; }
        public GamesModel Game { get; set; }

        public GamesToScreenshotsModel GamesToScreenshots { get; set; }
    }
}
