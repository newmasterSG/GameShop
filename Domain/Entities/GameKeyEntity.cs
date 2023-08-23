using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameKeyEntity
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public int GameId { get; set; }

        public GamesEntity Game { get; set; }
        public bool IsBuy { get; set; }

        public OrderEntity? Order { get; set; }

        public int? OrderId { get; set; }
    }
}
