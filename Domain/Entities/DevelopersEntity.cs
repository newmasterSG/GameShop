using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class DevelopersEntity : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public int? Games_count { get; set; }
        public string? Image_Background { get; set; }

        public List<GamesEntity> Games { get; set; }

        public List<GamesToDeveloperEntity> GamesToDevelopers { get; set; }
    }
}
