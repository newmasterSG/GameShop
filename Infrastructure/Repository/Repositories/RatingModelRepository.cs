using Infrastructure.Context;
using Infrastructure.Models.Rating;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RatingModelRepository : IRatingModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public RatingModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(RatingModel model)
        {
            _gameShopContext.RatingModels.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(RatingModel model)
        {
            await _gameShopContext.RatingModels.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(RatingModel rating)
        {
            _gameShopContext.RatingModels.Remove(rating);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(RatingModel rating)
        {
            _gameShopContext.RatingModels.Remove(rating);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<RatingModel> GetAll()
        {
            return _gameShopContext.RatingModels.ToList();
        }

        public async Task<IEnumerable<RatingModel>> GetAllAsync()
        {
            return await _gameShopContext.RatingModels.ToListAsync();
        }

        public RatingModel GetById(int id)
        {
            return _gameShopContext.RatingModels.Find(id);
        }

        public async Task<RatingModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.RatingModels.FindAsync(id);
        }

        public void Update(RatingModel rating)
        {
            _gameShopContext.RatingModels.Update(rating);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(RatingModel rating)
        {
            _gameShopContext.RatingModels.Update(rating);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
