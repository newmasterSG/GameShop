using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.PlatformInfo
{
    [Table("PlatformInfo")]
    public class PlatformInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public object Image { get; set; }
        public object YearEnd { get; set; }
        public int YearStart { get; set; }
        public int GamesCount { get; set; }
        public string ImageBackground { get; set; }
    }
}
