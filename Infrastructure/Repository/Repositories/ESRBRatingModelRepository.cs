using Infrastructure.Context;
using Infrastructure.Models.ESRBRating;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class ESRBRatingModelRepository : IESRBRatingModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public ESRBRatingModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(ESRBRatingModel model)
        {
            _gameShopContext.ESRBRatings.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(ESRBRatingModel model)
        {
            await _gameShopContext.ESRBRatings.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(ESRBRatingModel eSRBRating)
        {
            _gameShopContext.ESRBRatings.Remove(eSRBRating);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(ESRBRatingModel eSRBRating)
        {
            _gameShopContext.ESRBRatings.Remove(eSRBRating);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<ESRBRatingModel> GetAll()
        {
            return _gameShopContext.ESRBRatings.ToList();
        }

        public async Task<IEnumerable<ESRBRatingModel>> GetAllAsync()
        {
            return await _gameShopContext.ESRBRatings.ToListAsync();
        }

        public ESRBRatingModel GetById(int id)
        {
            return _gameShopContext.ESRBRatings.Find(id);
        }

        public async Task<ESRBRatingModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.ESRBRatings.FindAsync(id);
        }

        public void Update(ESRBRatingModel eSRBRating)
        {
            _gameShopContext.ESRBRatings.Update(eSRBRating);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(ESRBRatingModel eSRBRating)
        {
            _gameShopContext.ESRBRatings.Update(eSRBRating);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
