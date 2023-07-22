using Infrastructure.Models.AddedByStatus;
using Infrastructure.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.GamesToAddedByStatus
{
    [Table("GamesToAddedByStatus")]
    public class GamesToAddedByStatusModel
    {
        public int GameId { get; set; }
        public int AddedByStatusId { get; set; }

        public GamesModel Games { get; set; }

        public AddedByStatusModel AddedByStatus { get; set; }
    }
}
