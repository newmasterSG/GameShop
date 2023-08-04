using Domain.Models.Games;
using Domain.Models.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.GamesToLanguage
{
    [Table("GamesToLanguage")]
    public class GamesToLanguageModel
    {
        public int? GamesId { get; set; }
        public int? LanguageId { get; set; }

        public GamesModel Game { get; set; }

        public LanguageModel Language { get; set; }
    }
}
