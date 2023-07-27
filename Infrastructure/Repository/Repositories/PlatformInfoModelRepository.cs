using Infrastructure.Context;
using Infrastructure.Models.PlatformInfo;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class PlatformInfoModelRepository : IPlatformInfoModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public PlatformInfoModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(PlatformInfoModel model)
        {
            model.Id = 0;
            _gameShopContext.PlatformInfoModels.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(PlatformInfoModel model)
        {
            model.Id = 0;
            await _gameShopContext.PlatformInfoModels.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(PlatformInfoModel platformInfo)
        {
            _gameShopContext.PlatformInfoModels.Remove(platformInfo);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(PlatformInfoModel platformInfo)
        {
            _gameShopContext.PlatformInfoModels.Remove(platformInfo);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<PlatformInfoModel> GetAll()
        {
            return _gameShopContext.PlatformInfoModels.ToList();
        }

        public async Task<IEnumerable<PlatformInfoModel>> GetAllAsync()
        {
            return await _gameShopContext.PlatformInfoModels.ToListAsync();
        }

        public PlatformInfoModel GetById(int id)
        {
            return _gameShopContext.PlatformInfoModels.Find(id);
        }

        public async Task<PlatformInfoModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.PlatformInfoModels.FindAsync(id);
        }

        public void Update(PlatformInfoModel platformInfo)
        {
            _gameShopContext.PlatformInfoModels.Update(platformInfo);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(PlatformInfoModel platformInfo)
        {
            _gameShopContext.PlatformInfoModels.Update(platformInfo);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
