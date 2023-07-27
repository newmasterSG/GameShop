using Infrastructure.Context;
using Infrastructure.Models.Store;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class StoreModelRepository : IStoreModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public StoreModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(StoreModel model)
        {
            model.Id = 0;
            _gameShopContext.StoreModels.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(StoreModel model)
        {
            model.Id = 0;
            await _gameShopContext.StoreModels.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(StoreModel store)
        {
            _gameShopContext.StoreModels.Remove(store);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(StoreModel store)
        {
            _gameShopContext.StoreModels.Remove(store);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<StoreModel> GetAll()
        {
            return _gameShopContext.StoreModels.ToList();
        }

        public async Task<IEnumerable<StoreModel>> GetAllAsync()
        {
            return await _gameShopContext.StoreModels.ToListAsync();
        }

        public StoreModel GetById(int id)
        {
            return _gameShopContext.StoreModels.Find(id);
        }

        public async Task<StoreModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.StoreModels.FindAsync(id);
        }

        public void Update(StoreModel store)
        {
            _gameShopContext.StoreModels.Update(store);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(StoreModel store)
        {
            _gameShopContext.StoreModels.Update(store);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
