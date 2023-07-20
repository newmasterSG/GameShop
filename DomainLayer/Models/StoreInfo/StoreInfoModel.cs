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
        public int Games_Count { get; set; }
        public string Image_Background { get; set; }
    }
}
