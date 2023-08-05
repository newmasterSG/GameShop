using Domain.Entities.Games;
using Domain.Entities.Tags;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.GamesToTags
{
    public class GamesToTagsModel
    {
        public int? GamesId { get; set; }

        public int? TagsId { get; set; }

        public GamesModel Game { get; set; }
        public TagModel Tag { get; set; }
    }
}
