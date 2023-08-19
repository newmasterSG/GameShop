using Infrastructure.Context;
using Domain.Interfaces;
using Infrastructure.Repository.Repositories;
using ParsingData.Requests;
using Microsoft.EntityFrameworkCore;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.Extensions.Options;
using ParsingData.Importer;
using Domain.Entities;

namespace ParsingData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            List<Task<RootObject<GamesEntity>>> task = new List<Task<RootObject<GamesEntity>>>();

            string apiKey = "e5be80adcd7348d9bfe0c55a970b5215";

            string gamesUrl = "https://api.rawg.io/api/games?key={0}&developers={1}&page=";

            var optionsBuilder = new DbContextOptionsBuilder<GameShopContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GameShop;Trusted_Connection=True;TrustServerCertificate=true")
                          .EnableSensitiveDataLogging();

            using (GameShopContext gameShopContext = new GameShopContext(optionsBuilder.Options))
            {
                UnitOfWork<GameShopContext> unitOf = new UnitOfWork<GameShopContext>(gameShopContext);
                GamesEntity gam = new GamesEntity();
                GameImporter gameImporter = new GameImporter(gameShopContext);
                gam = await gameImporter.CreateGame(Seeding.Seed(), Seeding.SeedDev());
            }
        }
    }
}