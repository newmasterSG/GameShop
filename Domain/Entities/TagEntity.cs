using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TagEntity : EntityBase
    {
        public new int? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Language { get; set; }
        public int? GamesCount { get; set; }
        public string? ImageBackground { get; set; }

        public List<GamesEntity> Games { get; set; }
        public List<GamesToTagsEntity> ToTagsModels { get; set; }
    }
}
