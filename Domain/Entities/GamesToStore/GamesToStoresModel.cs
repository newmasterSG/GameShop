using Domain.Entities.Games;
using Domain.Entities.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GamesToStore
{
    public class GamesToStoresModel
    {
        public int? GameId { get; set; }

        public int? StoreId { get; set; }

        public GamesModel Game { get; set; }

        public StoreModel Store { get; set; }
    }
}
