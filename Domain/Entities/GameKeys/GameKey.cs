using Domain.Entities.Games;
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
    }
}
