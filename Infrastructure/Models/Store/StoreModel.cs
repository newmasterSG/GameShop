using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToStore;
using Infrastructure.Models.StoreInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models.Store
{
    [Table("Store")]
    public class StoreModel
    {
        public int Id { get; set; }
        public StoreInfoModel Store { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToStoresModel> GamesToStores { get; set; }
    }
}
