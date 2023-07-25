using Infrastructure.Context;
using Infrastructure.Models.Tags;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class TagModelRepository: ITagModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public TagModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(TagModel model)
        {
            _gameShopContext.Tags.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(TagModel tag)
        {
            await _gameShopContext.Tags.AddAsync(tag);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(TagModel tag)
        {
            _gameShopContext.Tags.Remove(tag);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(TagModel tag)
        {
            _gameShopContext.Tags.Remove(tag);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<TagModel> GetAll()
        {
            return _gameShopContext.Tags.ToList();
        }

        public async Task<IEnumerable<TagModel>> GetAllAsync()
        {
            return await _gameShopContext.Tags.ToListAsync();
        }

        public TagModel GetById(int id)
        {
            return _gameShopContext.Tags.Find(id);
        }

        public async Task<TagModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.Tags.FindAsync(id);
        }

        public void Update(TagModel tag)
        {
            _gameShopContext.Tags.Update(tag);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(TagModel tag)
        {
            _gameShopContext.Tags.Update(tag);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
