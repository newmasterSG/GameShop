using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GamesToTagsEntity
    {
        public int? GamesId { get; set; }

        public int? TagsId { get; set; }

        public GamesEntity Game { get; set; }
        public TagEntity Tag { get; set; }
    }
}
