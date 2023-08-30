using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PlatformInfoEntity : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Image { get; set; }
        public int? YearEnd { get; set; }
        public int? Yearstart { get; set; }
        public int Games_Count { get; set; }
        public string? ImageBackground { get; set; }
    }
}
