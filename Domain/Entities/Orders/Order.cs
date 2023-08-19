using Domain.Entities.GameKeys;
using Domain.Entities.Games;
using Domain.Entities.OrderToGame;

namespace Domain.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; } 
        public List<OrderGame> OrderedGames { get; set; }
        public decimal Price { get; set; }

        public ICollection<GamesModel> Games { get; set; }

        public ICollection<GameKey> GameKeys { get; set; }
    }
}
