using Domain.Entities.Games;
using Domain.Entities.GamesToStore;
using Domain.Entities.StoreInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Store
{
    public class StoreModel : EntityBase
    {
        public new int? Id { get; set; }
        public StoreInfoModel? Store { get; set; }

        public List<GamesModel> Games { get; set; }

        public List<GamesToStoresModel> GamesToStores { get; set; }
    }
}
