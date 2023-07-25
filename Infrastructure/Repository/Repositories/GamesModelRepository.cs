using Infrastructure.Context;
using Infrastructure.Models.Games;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class GamesModelRepository : IGamesModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public GamesModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(GamesModel model)
        {
            _gameShopContext.Games.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(GamesModel model)
        {
            await _gameShopContext.Games.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(GamesModel games)
        {
            _gameShopContext.Games.Remove(games);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(GamesModel games)
        {
            _gameShopContext.Games.Remove(games);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<GamesModel> GetAll()
        {
            return _gameShopContext.Games.ToList();
        }

        public async Task<IEnumerable<GamesModel>> GetAllAsync()
        {
            return await _gameShopContext.Games.ToListAsync();
        }

        public GamesModel GetById(int id)
        {
            return _gameShopContext.Games.Find(id);
        }

        public async Task<GamesModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.Games.FindAsync(id);
        }

        public void Update(GamesModel games)
        {
            _gameShopContext.Games.Update(games);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(GamesModel games)
        {
            _gameShopContext.Games.Update(games);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
