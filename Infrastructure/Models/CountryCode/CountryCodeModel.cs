using Infrastructure.Models.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.CountryCode
{
    [Table("CountryCode")]
    public class CountryCodeModel
    {
        public int Id { get; set; }

        public int CountryCode { get; set; }

        public string Name { get; set; }

        public ICollection<GamesModel> Games { get; set; }
    }
}
