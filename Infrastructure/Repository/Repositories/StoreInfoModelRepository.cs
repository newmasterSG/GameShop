using Infrastructure.Context;
using Infrastructure.Models.StoreInfo;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class StoreInfoModelRepository : IStoreInfoModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public StoreInfoModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(StoreInfoModel model)
        {
            _gameShopContext.StoreInfoModels.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(StoreInfoModel model)
        {
            await _gameShopContext.StoreInfoModels.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(StoreInfoModel storeInfo)
        {
            _gameShopContext.StoreInfoModels.Remove(storeInfo);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(StoreInfoModel storeInfo)
        {
            _gameShopContext.StoreInfoModels.Remove(storeInfo);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<StoreInfoModel> GetAll()
        {
            return _gameShopContext.StoreInfoModels.ToList();
        }

        public async Task<IEnumerable<StoreInfoModel>> GetAllAsync()
        {
            return await _gameShopContext.StoreInfoModels.ToListAsync();
        }

        public StoreInfoModel GetById(int id)
        {
            return _gameShopContext.StoreInfoModels.Find(id);
        }

        public async Task<StoreInfoModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.StoreInfoModels.FindAsync(id);
        }

        public void Update(StoreInfoModel storeInfo)
        {
            _gameShopContext.StoreInfoModels.Update(storeInfo);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(StoreInfoModel storeInfo)
        {
            _gameShopContext.StoreInfoModels.Update(storeInfo);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
