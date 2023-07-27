using Infrastructure.Context;
using Infrastructure.Models.Genres;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class GenreModelRepository : IGenreModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public GenreModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(GenreModel model)
        {
            model.Id = 0;
            _gameShopContext.Genres.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(GenreModel model)
        {
            model.Id = 0;
            await _gameShopContext.Genres.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(GenreModel genre)
        {
            _gameShopContext.Genres.Remove(genre);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(GenreModel genre)
        {
            _gameShopContext.Genres.Remove(genre);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<GenreModel> GetAll()
        {
            return _gameShopContext.Genres.ToList();
        }

        public async Task<IEnumerable<GenreModel>> GetAllAsync()
        {
            return await _gameShopContext.Genres.ToListAsync();
        }

        public GenreModel GetById(int id)
        {
            return _gameShopContext.Genres.Find(id);
        }

        public async Task<GenreModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.Genres.FindAsync(id);
        }

        public void Update(GenreModel genre)
        {
            _gameShopContext.Genres.Update(genre);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(GenreModel genre)
        {
            _gameShopContext.Genres.Update(genre);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
