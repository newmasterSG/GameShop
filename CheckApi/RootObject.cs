using DomainLayer.Models.AddedByStatus;
using DomainLayer.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckApi
{
    public class RootObject
    {
        public int Count { get; set; }
        public List<GamesModel> Results { get; set; }
    }
}
