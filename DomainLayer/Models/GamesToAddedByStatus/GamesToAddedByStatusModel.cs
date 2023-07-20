using DomainLayer.Models.AddedByStatus;
using DomainLayer.Models.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.GamesToAddedByStatus
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
