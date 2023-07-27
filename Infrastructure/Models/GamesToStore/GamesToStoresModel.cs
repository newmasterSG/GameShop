using Infrastructure.Models.Games;
using Infrastructure.Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.GamesToStore
{
    [Table("GamesToStores")]
    public class GamesToStoresModel
    {
        public int? GameId { get; set; }

        public int? StoreId { get; set; }

        public GamesModel Game { get; set; }

        public StoreModel Store { get; set; }
    }
}
