using Infrastructure.Context;
using Infrastructure.Models.Developer;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class DevelopersModelRepository : IDevelopersModelRepository
    {
        private readonly GameShopContext _gameShopContext;
        public DevelopersModelRepository(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(DevelopersModel model)
        {
            _gameShopContext.Developers.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(DevelopersModel model)
        {
            await _gameShopContext.Developers.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(DevelopersModel addedByStatus)
        {
            _gameShopContext.Developers.Remove(addedByStatus);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(DevelopersModel addedByStatus)
        {
            _gameShopContext.Developers.Remove(addedByStatus);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<DevelopersModel> GetAll()
        {
            return _gameShopContext.Developers.ToList();
        }

        public async Task<IEnumerable<DevelopersModel>> GetAllAsync()
        {
            return await _gameShopContext.Developers.ToListAsync();
        }

        public DevelopersModel GetById(int id)
        {
            return _gameShopContext.Developers.Find(id);
        }

        public async Task<DevelopersModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.Developers.FindAsync(id);
        }

        public void Update(DevelopersModel addedByStatus)
        {
            _gameShopContext.Developers.Update(addedByStatus);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(DevelopersModel addedByStatus)
        {
            _gameShopContext.Developers.Update(addedByStatus);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
