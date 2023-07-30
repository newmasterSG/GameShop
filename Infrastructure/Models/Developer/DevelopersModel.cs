using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToDeveloper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Developer
{
    [Table("Developer")]
    public class DevelopersModel: EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public int? Games_count { get; set; }
        public string? Image_Background { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToDeveloperModel> GamesToDevelopers { get; set; }
    }
}
