using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities;
using Domain.Interfaces;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderServices : IOrderServices
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
        public void CreateOrder(UserEntity user, Dictionary<int, int> gameIds, decimal price)
        {
            Guid guid = new Guid(user.Id);

            var order = new OrderEntity
            {
                OrderDate = DateTime.UtcNow,
                UserId = guid,
                OrderedGames = new List<OrderGameEntity>(),
                Price = price,
                GameKeys = new List<GameKeyEntity>(),
            };

            foreach (var gameId in gameIds)
            {
                // Take game by id
                var game = _context.GetRepository<GamesEntity>().GetById(gameId.Key);

                if (game != null)
                {
                    //Taking key that false isBuy field
                    var keys = _context.GetRepository<GameKeyEntity>()
                        .List(g => g.GameId == game.Id).
                        Where(k => k.IsBuy == false)
                        .Take(gameId.Value).ToList();
                    if (keys != null)
                    {
                        foreach (var key in keys)
                        {
                            key.IsBuy = true;
                            order.GameKeys.Add(key);
                        }

                        order.OrderedGames.Add(new OrderGameEntity { Game = game, });
                    }
                    else
                    {
                        throw new Exception($"No keys available for game '{game.Name}'.");
                    }
                }
            }
            user.GameOwning += order.GameKeys.Count;

            _context.GetRepository<UserEntity>().Update(user);
            _context.GetRepository<OrderEntity>().Insert(order);
            _context.Save();
        }

        public async Task<List<OrderPurchaseDto>> GetOrderPurchasesAsync(string userId)
        {
            var orders = new List<OrderPurchaseDto>();

            var user = _context.GetRepository<UserEntity>().Find(u => u.Id == userId);

            var dbOrders = await _context.GetRepository<OrderEntity>().ListAsync(o => o.UserId.ToString() == user.Id);

            foreach (var dbOrder in dbOrders)
            {
                var dbOrderedGames = await _context.GetRepository<OrderGameEntity>().ListAsync(og => og.OrderId == dbOrder.Id);

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
                    var game = await _context.GetRepository<GamesEntity>().GetByIdAsync(orderedGame.GameId);
                    orderPurchase.Games.Add(game.Name);
                    var dbGameKeys = await _context.GetRepository<GameKeyEntity>().ListAsync(k => k.GameId == game.Id);
                    var gameKeys = dbGameKeys.Where(gk => gk.IsBuy && gk.OrderId == dbOrder.Id).Select(gk => gk.Key);
                    orderPurchase.Keys.AddRange(gameKeys);
                }

                orders.Add(orderPurchase);
            }

            return orders;
        }
    }
}
