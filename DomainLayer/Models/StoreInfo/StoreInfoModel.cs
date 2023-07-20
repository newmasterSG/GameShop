using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.StoreInfo
{
    [Table("StoreInfo")]
    public class StoreInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Domain { get; set; }
        public int GamesCount { get; set; }
        public string ImageBackground { get; set; }
    }
}
