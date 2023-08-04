using Domain.Models.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CountryCode
{
    [Table("CountryCode")]
    public class CountryCodeModel: EntityBase
    {
        public new int Id { get; set; }

        public int CountryCode { get; set; }

        public string Name { get; set; }

        public ICollection<GamesModel> Games { get; set; }
    }
}
