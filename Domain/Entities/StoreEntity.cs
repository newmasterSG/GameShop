using Domain.Entities.StoreInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Store
{
    public class StoreEntity : EntityBase
    {
        public new int? Id { get; set; }
        public StoreInfoEntity? Store { get; set; }

        public List<GamesEntity> Games { get; set; }

        public List<GamesToStoresEntity> GamesToStores { get; set; }
    }
}
