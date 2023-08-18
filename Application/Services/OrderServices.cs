using Application.DTO;
using Domain.Entities.GameKeys;
using Domain.Entities.Games;
using Domain.Entities.Orders;
using Domain.Entities.OrderToGame;
using Infrastructure.UnitOfWork.Interface;
using Infrastructure.User;
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
                GameKeys = new List<GameKey>(),
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
                            order.GameKeys.Add(key);
                        }

                        order.OrderedGames.Add(new OrderGame { Game = game, } );
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

        public async Task<List<OrderPurchaseDto>> GetOrderPurchases(string userName)
        {
            var orders = new List<OrderPurchaseDto>();

            var user = _context.GetRepository<UserModel>().Find(u => u.UserName == userName);

            var dbOrders = await _context.GetRepository<Order>().ListAsync(o => o.UserId.ToString() == user.Id);
            
            foreach (var dbOrder in dbOrders)
            {
                var dbOrderedGames = await _context.GetRepository<OrderGame>().ListAsync(og => og.OrderId == dbOrder.Id);

                var orderPurchase = new OrderPurchaseDto
                {
                    Id = dbOrder.Id,
                    Count = dbOrderedGames.Count(),
                    TotalPrice = dbOrder.Price,
                    Games = new List<string>(),
                    Keys = new List<Guid>()
                };

                foreach (var orderedGame in dbOrderedGames)
                {
                    var game = await _context.GetRepository<GamesModel>().GetByIdAsync(orderedGame.GameId);
                    orderPurchase.Games.Add(game.Name);
                    var dbGameKeys = await _context.GetRepository<GameKey>().ListAsync(k => k.GameId == game.Id);
                    var gameKeys = dbGameKeys.Where(gk => gk.IsBuy && gk.OrderId == dbOrder.Id).Select(gk => gk.Key);
                    orderPurchase.Keys.AddRange(gameKeys);
                }

                orders.Add(orderPurchase);
            }

            return orders;
        }
    }
}
