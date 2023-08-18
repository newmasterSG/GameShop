using Domain.Entities.Games;
using Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GameKeys
{
    public class GameKey
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public int GameId { get; set; }

        public GamesModel Game { get; set; }
        public bool IsBuy { get; set; }

        public Order? Order { get; set; }

        public int? OrderId { get; set; }
    }
}
