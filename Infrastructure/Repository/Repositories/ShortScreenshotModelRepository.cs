using Infrastructure.Context;
using Infrastructure.Models.ShortScreenshot;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class ShortScreenshotModelRepository : IShortScreenshotModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public ShortScreenshotModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(ShortScreenshotModel model)
        {
            _gameShopContext.ShortScreenshotModels.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(ShortScreenshotModel model)
        {
            await _gameShopContext.ShortScreenshotModels.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(ShortScreenshotModel shortScreenshot)
        {
            _gameShopContext.ShortScreenshotModels.Remove(shortScreenshot);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(ShortScreenshotModel shortScreenshot)
        {
            _gameShopContext.ShortScreenshotModels.Remove(shortScreenshot);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<ShortScreenshotModel> GetAll()
        {
            return _gameShopContext.ShortScreenshotModels.ToList();
        }

        public async Task<IEnumerable<ShortScreenshotModel>> GetAllAsync()
        {
            return await _gameShopContext.ShortScreenshotModels.ToListAsync();
        }

        public ShortScreenshotModel GetById(int id)
        {
            return _gameShopContext.ShortScreenshotModels.Find(id);
        }

        public async Task<ShortScreenshotModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.ShortScreenshotModels.FindAsync(id);
        }

        public void Update(ShortScreenshotModel shortScreenshot)
        {
            _gameShopContext.ShortScreenshotModels.Update(shortScreenshot);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(ShortScreenshotModel shortScreenshot)
        {
            _gameShopContext.ShortScreenshotModels.Update(shortScreenshot);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
