namespace Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public List<OrderGameEntity> OrderedGames { get; set; }
        public decimal Price { get; set; }

        public ICollection<GamesEntity> Games { get; set; }

        public ICollection<GameKeyEntity> GameKeys { get; set; }
    }
}
