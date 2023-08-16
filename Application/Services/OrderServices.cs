using Domain.Entities.GameKeys;
using Domain.Entities.Games;
using Domain.Entities.Orders;
using Domain.Entities.OrderToGame;
using Infrastructure.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderServices
    {
        private readonly IUnitOfWork _context;
        public OrderServices(IUnitOfWork context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that create Order and do bool field true
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameIds"></param>
        /// <exception cref="Exception"></exception>
        public void CreateOrder(string userId, Dictionary<int,int> gameIds, decimal price)
        {
            Guid guid = new Guid(userId);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = guid,
                OrderedGames = new List<OrderGame>(),
                Price = price,
            };

            foreach (var gameId in gameIds)
            {
                // Take game by id
                var game = _context.GetRepository<GamesModel>().GetById(gameId.Key);

                if (game != null)
                {
                    //Taking key that false isBuy field
                    var keys = _context.GetRepository<GameKey>().List(g => g.GameId == game.Id).Where(k => k.IsBuy == false).Take(gameId.Value).ToList();
                    if (keys != null)
                    {
                        foreach(var key in keys)
                        {
                            key.IsBuy = true;
                        }

                        order.OrderedGames.Add(new OrderGame { Game = game, });
                    }
                    else
                    {
                        throw new Exception($"No keys available for game '{game.Name}'.");
                    }
                }
            }

            _context.GetRepository<Order>().Insert(order);
            _context.Save();
        }
    }
}
