using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToAddedByStatus;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.AddedByStatus
{
    [Table("AddedByStatus")]
    public class AddedByStatusModel
    {
        public int? Id { get; set; }
        public int? Yet { get; set; }
        public int? Owned { get; set; }
        public int? Beaten { get; set; }
        public int? Toplay { get; set; }
        public int? Dropped { get; set; }
        public int? Playing { get; set; }
        public List<GamesModel> Games { get; set; }

        public List<GamesToAddedByStatusModel> GamesToAddedByStatus { get; set; }
    }
}
