using DomainLayer.Models.Games;
using DomainLayer.Models.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.GamesToLanguage
{
    [Table("GamesToLanguage")]
    public class GamesToLanguageModel
    {
        public int Id { get; set; }
        public int GamesId { get; set; }
        public int LanguageId { get; set; }

        public GamesModel Game { get; set; }

        public LanguageModel Language { get; set; }
    }
}
