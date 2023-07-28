using Infrastructure.Context;
using Infrastructure.Models.ESRBRating;
using Infrastructure.Models.Games;
using Infrastructure.Models.Genres;
using Infrastructure.Models.Platform;
using Infrastructure.Models.Rating;
using Infrastructure.Models.ShortScreenshot;
using Infrastructure.Models.Store;
using Infrastructure.Models.Tags;
using Infrastructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ParsingData.Requests;
using ServicesLayer.Services.Service;
using System;

namespace ParsingData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            GetRequest getRequest = new GetRequest(client, "https://api.rawg.io/api/games?key=e5be80adcd7348d9bfe0c55a970b5215&page=");

            var gameList = await new GameDeserialize().Deserialize(await getRequest.GetJson(12));

            using (GameShopContext gameShopContext = new GameShopContext())
            {
                GamesModelService gamesModelService = new GamesModelService(new GamesModelRepository(gameShopContext));
                foreach (var game in gameList.Results)
                {
                    var gam = await GameImporter.CreateGame(game);

                    await Console.Out.WriteLineAsync($"Game with name : {gam.Name} was added");

                    var existingGame = gameShopContext.Games.FirstOrDefault(i => i.Name == game.Name);

                    if (existingGame == null)
                    {
                        await gamesModelService.AddAsync(gam);
                    }
                    else
                    {
                    }
                }
            }
        }
    }
}