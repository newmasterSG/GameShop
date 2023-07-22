using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToScreenshots;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.ShortScreenshot
{
    [Table("ShortScreenshot")]
    public class ShortScreenshotModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public GamesModel Game { get; set; }

        public GamesToScreenshotsModel GamesToScreenshots { get; set; }
    }
}
