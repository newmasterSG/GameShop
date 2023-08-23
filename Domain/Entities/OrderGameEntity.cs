using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderGameEntity
    {
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int GameId { get; set; }
        public GamesEntity Game { get; set; }
    }
}
