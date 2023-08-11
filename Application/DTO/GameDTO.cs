using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class GameDTO
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Image { get; set; }
       public decimal Price { get; set; }
       public int Owned { get; set; }
    }

    public class GamesViewDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Tags { get; set; }

        public List<string> ScrenShoots { get; set; }

        public List<string> Stores { get; set; }
    }
}
