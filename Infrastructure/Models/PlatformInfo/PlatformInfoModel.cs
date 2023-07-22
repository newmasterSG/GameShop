using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.PlatformInfo
{
    [Table("PlatformInfo")]
    public class PlatformInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public int? Year_End { get; set; }
        public int? Year_start { get; set; }
        public int Games_Count { get; set; }
        public string Image_Background { get; set; }
    }
}
