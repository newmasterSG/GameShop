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

        public void CreateOrder(string userId, List<int> gameIds)
        {
            Guid guid = new Guid(userId);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = guid,
                OrderedGames = new List<OrderGame>(),
            };

            foreach (var gameId in gameIds)
            {
                var game = _context.GetRepository<GamesModel>().GetById(gameId);
                if (game != null)
                {
                    var keys = _context.GetRepository<GameKey>().List(g => g.GameId == game.Id);
                    //var keys = game.GameKeys;
                    if (keys != null)
                    {
                        game.GameKeys.RemoveRange
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
