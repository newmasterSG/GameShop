using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class OrderDTO
    {
        public Dictionary<int, int> GameIds { get; set; }
    }

    public class OrderPurchaseDto
    {
        public int Id { get; set; }
        public List<string> Games { get; set; }

        public List<Guid> Keys { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
