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
using Infrastructure.Models.StoreInfo;
using Infrastructure.Models.Tags;
using Infrastructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            List<Task<RootObject<GamesModel>>> task = new List<Task<RootObject<GamesModel>>>();
            string apiKey = "e5be80adcd7348d9bfe0c55a970b5215";
            //GetRequest devRequest = new GetRequest(client, "https://api.rawg.io/api/developers?key=e5be80adcd7348d9bfe0c55a970b5215&page=");
            string gamesUrl = "https://api.rawg.io/api/games?key={0}&developers={1}&page=";
            //List<Task<RootObject<DevelopersModel>>> task2 = new List<Task<RootObject<DevelopersModel>>>();
            using (GameShopContext gameShopContext = new GameShopContext())
            {
                Services<GamesModel> gamesModelService = new Services<GamesModel>(new Repository<GamesModel>(gameShopContext));
                Services<DevelopersModel> developerServices = new Services<DevelopersModel>(new Repository<DevelopersModel>(gameShopContext));
                GamesModel gam = new GamesModel();
                GameImporter gameImporter = new GameImporter(gameShopContext);

                //for (int i = 1; i <= 3; i++)
                //{
                //    task2.Add(new Deserializer<DevelopersModel>().Deserialize(await devRequest.GetJson(i)));
                //}

                //var results2 = await Task.WhenAll(task2);

                //foreach (var result in results2)
                //{
                //    foreach (var item in result.Results)
                //    {
                //        DevelopersModel model = await DeveloperImporter.CreateDeveloper(item);

                //        await developerServices.AddAsync(model);
                //    }
                //}

                var existDev = await developerServices.GetAllAsync();
                var exist = existDev.Where(x => x.Id % 3 == 0).TakeLast(3).ToList();
                var devList = new List<DevelopersModel>();
                foreach (var dev in exist)
                {
                    devList.Add(dev);
                    var url = string.Format(gamesUrl, apiKey, dev.Slug, "{0}");
                    GetRequest games = new GetRequest(client, url);
                    for (int i = 1; i <= 1; i++)
                    {
                        task.Add(new Deserializer<GamesModel>().Deserialize(await games.GetJson(i)));
                    }
                }

                var results = await Task.WhenAll(task);
                foreach(var dev in devList)
                {
                    foreach (var result in results)
                    {
                        foreach (var item in result.Results)
                        {
                            gam = await gameImporter.CreateGame(item, dev);
                            await gamesModelService.AddAsync(gam);
                        }
                    }
                }

            }
        }
    }
}