using Domain.Models.Games;
using Domain.Models.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.GamesToTags
{
    [Table("GamesToTags")]
    public class GamesToTagsModel
    {
        public int? GamesId { get; set; }

        public int? TagsId { get; set; }

        public GamesModel Game { get; set; }
        public TagModel Tag { get; set; }
    }
}
