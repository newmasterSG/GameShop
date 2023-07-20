using DomainLayer.Models.Games;
using DomainLayer.Models.GamesToAddedByStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.AddedByStatus
{
    [Table("AddedByStatus")]
    public class AddedByStatusModel
    {
        public int Yet { get; set; }
        public int Owned { get; set; }
        public int Beaten { get; set; }
        public int Toplay { get; set; }
        public int Dropped { get; set; }
        public int Playing { get; set; }
        public List<GamesModel> Games { get; set; }

        public List<GamesToAddedByStatusModel> GamesToAddedByStatus { get; set; }
    }
}
