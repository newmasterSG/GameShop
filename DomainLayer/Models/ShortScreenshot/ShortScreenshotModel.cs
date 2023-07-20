using DomainLayer.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.ShortScreenshot
{
    [Table("ShortScreenshot")]
    public class ShortScreenshotModel
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public GamesModel Game { get; set; }
    }
}
