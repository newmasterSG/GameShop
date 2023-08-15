using Domain.Entities.Games;
using Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderToGame
{
    public class OrderGame
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int GameId { get; set; }
        public GamesModel Game { get; set; }
    }
}
