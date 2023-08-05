using Domain.Entities.Games;
using Domain.Entities.GamesToDeveloper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Developer
{
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
