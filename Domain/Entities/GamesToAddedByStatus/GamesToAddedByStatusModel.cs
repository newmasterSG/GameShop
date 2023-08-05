using Domain.Entities.AddedByStatus;
using Domain.Entities.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.GamesToAddedByStatus
{
    public class GamesToAddedByStatusModel
    {
        public int? GameId { get; set; }
        public int? AddedByStatusId { get; set; }

        public GamesModel Games { get; set; }

        public AddedByStatusModel AddedByStatus { get; set; }
    }
}
