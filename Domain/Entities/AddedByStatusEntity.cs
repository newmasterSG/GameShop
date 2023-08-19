using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class AddedByStatusEntity : EntityBase
    {
        public new int? Id { get; set; }
        public int? Yet { get; set; }
        public int? Owned { get; set; }
        public int? Beaten { get; set; }
        public int? Toplay { get; set; }
        public int? Dropped { get; set; }
        public int? Playing { get; set; }
        public List<GamesEntity> Games { get; set; }
    }
}
