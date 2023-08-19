using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GamesToDeveloper
{
    public class GamesToDeveloperEntity
    {
        public int GameId { get; set; }
        public GamesEntity Game { get; set; }
        public int DeveloperId { get; set; }
        public DevelopersEntity Developer { get; set; }
    }
}
