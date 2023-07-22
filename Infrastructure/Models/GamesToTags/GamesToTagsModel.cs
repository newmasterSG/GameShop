using Infrastructure.Models.Games;
using Infrastructure.Models.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.GamesToTags
{
    [Table("GamesToTags")]
    public class GamesToTagsModel
    {
        public int GamesId { get; set; }

        public int TagsId { get; set; }

        public GamesModel Game { get; set; }
        public TagModel Tag { get; set; }
    }
}
