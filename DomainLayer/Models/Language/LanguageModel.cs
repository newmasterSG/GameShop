using DomainLayer.Models.GamesToLanguage;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Language
{
    [Table("Language")]
    public class LanguageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GamesToLanguageModel> GamesToLanguages { get; set; }
    }
}
