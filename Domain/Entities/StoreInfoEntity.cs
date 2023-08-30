using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class StoreInfoEntity : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Domain { get; set; }
        public int? GamesCount { get; set; }
        public string? ImageBackground { get; set; }
    }
}
