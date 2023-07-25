using Infrastructure.Context;
using Infrastructure.Models.Platform;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class PlatformModelRepository : IPlatformModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public PlatformModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(PlatformModel model)
        {
            _gameShopContext.PlatformModels.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(PlatformModel model)
        {
            await _gameShopContext.PlatformModels.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(PlatformModel platform)
        {
            _gameShopContext.PlatformModels.Remove(platform);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(PlatformModel platform)
        {
            _gameShopContext.PlatformModels.Remove(platform);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<PlatformModel> GetAll()
        {
            return _gameShopContext.PlatformModels.ToList();
        }

        public async Task<IEnumerable<PlatformModel>> GetAllAsync()
        {
            return await _gameShopContext.PlatformModels.ToListAsync();
        }

        public PlatformModel GetById(int id)
        {
            return _gameShopContext.PlatformModels.Find(id);
        }

        public async Task<PlatformModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.PlatformModels.FindAsync(id);
        }

        public void Update(PlatformModel platform)
        {
            _gameShopContext.PlatformModels.Update(platform);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(PlatformModel platform)
        {
            _gameShopContext.PlatformModels.Update(platform);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
