using Domain.Entities.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GamesToStoresEntity
    {
        public int? GameId { get; set; }

        public int? StoreId { get; set; }

        public GamesEntity Game { get; set; }

        public StoreEntity Store { get; set; }
    }
}
