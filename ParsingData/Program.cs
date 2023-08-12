using Infrastructure.Context;
using Domain.Entities.Developer;
using Domain.Entities.Games;
using Infrastructure.Repository.Repositories;
using ParsingData.Requests;
using Microsoft.EntityFrameworkCore;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.Extensions.Options;
using ParsingData.Importer;

namespace ParsingData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            List<Task<RootObject<GamesModel>>> task = new List<Task<RootObject<GamesModel>>>();

            string apiKey = "e5be80adcd7348d9bfe0c55a970b5215";

            string gamesUrl = "https://api.rawg.io/api/games?key={0}&developers={1}&page=";

            var optionsBuilder = new DbContextOptionsBuilder<GameShopContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GShop;Trusted_Connection=True;TrustServerCertificate=true")
                          .EnableSensitiveDataLogging();

            using (GameShopContext gameShopContext = new GameShopContext(optionsBuilder.Options))
            {
                UnitOfWork<GameShopContext> unitOf = new UnitOfWork<GameShopContext>(gameShopContext);
                GamesModel gam = new GamesModel();
                GameImporter gameImporter = new GameImporter(gameShopContext);
                gam = await gameImporter.CreateGame(Seeding.Seed(), Seeding.SeedDev());
            }
        }
    }
}