using DomainLayer.Models.Games;
using DomainLayer.Models.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.GamesToTags
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
