using Domain.Entities.Games;
using Domain.Entities.GamesToTags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tags
{
    public class TagModel : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Language { get; set; }
        public int? Games_Count { get; set; }
        public string? Image_Background { get; set; }

        public List<GamesModel> Games { get; set; }
        public List<GamesToTagsModel> ToTagsModels { get; set; }
    }
}
