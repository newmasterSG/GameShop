using Infrastructure.Context;
using Infrastructure.Models.AddedByStatus;
using Infrastructure.Models.Developer;
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
using ServicesLayer.Services.Interfaces;
using ServicesLayer.Services.Service;
using System;
using System.Text;

namespace ParsingData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            //GetRequest devgetRequest = new GetRequest(client, "https://api.rawg.io/api/developers?key=e5be80adcd7348d9bfe0c55a970b5215&page=");
            //var developerList = await new Deserializer<DevelopersModel>().Deserialize(await devgetRequest.GetJson(4));
            List<Task<RootObject<GamesModel>>> task = new List<Task<RootObject<GamesModel>>>();

            using (GameShopContext gameShopContext = new GameShopContext())
            {
                Services<GamesModel> gamesModelService = new Services<GamesModel>(new Repository<GamesModel>(gameShopContext));
                Services<DevelopersModel> developerServices = new Services<DevelopersModel>(new Repository<DevelopersModel>(gameShopContext));
                GamesModel gam = new GamesModel();
                var existingDeveloper = await developerServices.GetAllAsync();
                foreach (var developer in existingDeveloper)
                {
                    var existDeveloper = gameShopContext.Developers.FirstOrDefault(i => i.Name == developer.Name);
                    string Url = $"https://api.rawg.io/api/games?key=e5be80adcd7348d9bfe0c55a970b5215&developers={developer.Slug}&page=";
                    GetRequest gameGetRequest = new GetRequest(client, Url);
                    for (int i = 1; i <= 2; i++)
                    {
                        task.Add(new Deserializer<GamesModel>().Deserialize(await gameGetRequest.GetJson(i)));
                    }

                    var results = await Task.WhenAll(task);

                    foreach (var result in results)
                    {
                        foreach (var item in result.Results)
                        {
                            gam = await GameImporter.CreateGame(item, developer);
                            await gamesModelService.AddAsync(gam);
                            //var existingGame = gameShopContext.Games.FirstOrDefault(i => i.Name == gam.Name);
                            //if (existingGame == null)
                            //{
                            //    await gamesModelService.AddAsync(gam);
                            //}
                            //else
                            //{
                            //}
                        }
                    }
                }
            }
        }
    }
}