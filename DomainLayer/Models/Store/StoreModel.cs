using DomainLayer.Models.Games;
using DomainLayer.Models.StoreInfo;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Store
{
    [Table("Store")]
    public class StoreModel
    {
        public int Id { get; set; }
        public StoreInfoModel StoreInfo { get; set; }

        public List<GamesModel> Games { get; set; }
    }
}
