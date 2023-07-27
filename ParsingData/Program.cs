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
            string jsonbody = string.Empty;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.rawg.io/api/games?key=e5be80adcd7348d9bfe0c55a970b5215&page=4"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                jsonbody = body;
            }

            var gameList = JsonConvert.DeserializeObject<RootObject>(jsonbody);
            using (GameShopContext gameShopContext = new GameShopContext())
            {
                GamesModelService gamesModelService = new GamesModelService(new GamesModelRepository(gameShopContext));
                foreach (var game in gameList.Results)
                {
                    if (game.ESRB_Rating == null)
                    {
                        game.ESRB_Rating = new ESRBRatingModel();
                    }
                    else
                    {
                        game.ESRB_Rating = new ESRBRatingModel()
                        {
                            Games = game.ESRB_Rating.Games,
                            Name = game.ESRB_Rating.Name,
                            Slug = game.ESRB_Rating.Slug,
                            GamesToESRBRating = game.ESRB_Rating.GamesToESRBRating,
                        };
                    }

                    var Pl = new List<Infrastructure.Models.Platform.PlatformModel>();
                    var Genresw = new List<GenreModel>();
                    var rat = new List<RatingModel>();
                    var Sto = new List<StoreModel>();
                    var tag = new List<TagModel>();
                    var Scr = new List<ShortScreenshotModel>();

                    foreach (var item in game.Genres)
                    {
                        Genresw.Add(new GenreModel()
                        {
                            Slug = item.Slug,
                            Name = item.Name,
                            Image_Background = item.Image_Background,
                            Games = item.Games,
                            GamesCount = item.GamesCount,
                        });
                    }

                    foreach (var pl in game.Platforms)
                    {
                        Pl.Add(new PlatformModel()
                        {
                            Games = pl.Games,
                            Platform = new Infrastructure.Models.PlatformInfo.PlatformInfoModel()
                            {
                                Games_Count = pl.Platform.Games_Count,
                                Name = pl.Platform.Name,
                                Slug = pl.Platform.Slug,
                                Image = pl.Platform.Image,
                                Year_End = pl.Platform.Year_End,
                                Year_start = pl.Platform.Year_start,
                                Image_Background = pl.Platform.Image_Background,
                            },
                            Released_At = pl.Released_At,
                            Requirements_En = pl.Requirements_En,
                            Requirements_Ru = pl.Requirements_Ru,
                        });
                    }

                    foreach (var r in game.Ratings)
                    {
                        rat.Add(new RatingModel()
                        {
                            Count = r.Count,
                            Games = r.Games,
                            Title = r.Title,
                            Percent = r.Percent,
                        });
                    }

                    foreach (var s in game.Stores)
                    {
                        Sto.Add(new StoreModel()
                        {
                            Store = new Infrastructure.Models.StoreInfo.StoreInfoModel()
                            {
                                Slug = s.Store.Slug,
                                Name = s.Store.Name,
                                Domain = s.Store.Domain,
                                Games_Count = s.Store.Games_Count,
                                Image_Background = s.Store.Image_Background,
                            },
                            Games = s.Games,
                        });
                    }

                    foreach (var t in game.Tags)
                    {
                        tag.Add(new TagModel()
                        {
                            Name = t.Name,
                            Slug = t.Slug,
                            Language = t.Language,
                            Games_Count = t.Games_Count, 
                            Image_Background = t.Image_Background,
                        });
                    }

                    foreach (var g in game.Short_Screenshots)
                    {
                        Scr.Add(new ShortScreenshotModel()
                        {
                            Game = g.Game,
                            Image = g.Image,
                        });
                    }

                    var gam = new GamesModel()
                    {
                        Added_By_Status = game.Added_By_Status,
                        Name = game.Name,
                        Background_Image = game.Background_Image,
                        Dominant_Color = game.Dominant_Color,
                        ESRB_Rating = game.ESRB_Rating,
                        Short_Screenshots = Scr,
                        Genres = Genresw,
                        Platforms = Pl,
                        Ratings = rat,
                        Stores = Sto,
                        Tags = tag,
                        Metacritic = game.Metacritic,
                        Playtime = game.Playtime,
                        Rating = game.Rating,
                        Rating_Top = game.Rating_Top,
                        Ratings_Count = game.Ratings_Count,
                        Released = game.Released,
                        Reviews_Count = game.Reviews_Count,
                        Reviews_Text_Count = game.Reviews_Text_Count,
                        Slug = game.Slug,
                        Suggestions_Count = game.Suggestions_Count,
                        Tba = game.Tba,
                        Updated = game.Updated,
                        Saturated_Color = game.Saturated_Color,
                    };

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