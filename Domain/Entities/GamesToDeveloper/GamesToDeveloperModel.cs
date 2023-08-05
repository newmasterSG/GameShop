using Domain.Entities.Developer;
using Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GamesToDeveloper
{
    public class GamesToDeveloperModel
    {
        public int GameId { get; set; }
        public GamesModel Game { get; set; }
        public int DeveloperId { get; set; }
        public DevelopersModel Developer { get; set; }
    }
}
