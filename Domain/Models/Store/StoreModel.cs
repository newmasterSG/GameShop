using Domain.Models.Games;
using Domain.Models.GamesToStore;
using Domain.Models.StoreInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Store
{
    [Table("Store")]
    public class StoreModel : EntityBase
    {
        public new int? Id { get; set; }
        public StoreInfoModel? Store { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToStoresModel> GamesToStores { get; set; }
    }
}
