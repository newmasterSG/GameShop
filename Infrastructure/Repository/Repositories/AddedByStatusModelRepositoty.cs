using Infrastructure.Context;
using Infrastructure.Models.AddedByStatus;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class AddedByStatusModelRepositoty : IAddedByStatusModelRepositoty
    {
        private readonly GameShopContext _gameShopContext;
        public AddedByStatusModelRepositoty(GameShopContext gameShopContext)
        {
            _gameShopContext = gameShopContext;
        }

        public void Add(AddedByStatusModel model)
        {
            _gameShopContext.AddedByStatus.Add(model);
            _gameShopContext.SaveChanges();
        }

        public async Task AddAsync(AddedByStatusModel model)
        {
            await _gameShopContext.AddedByStatus.AddAsync(model);
            await _gameShopContext.SaveChangesAsync();
        }

        public void Delete(AddedByStatusModel addedByStatus)
        {
            _gameShopContext.AddedByStatus.Remove(addedByStatus);
            _gameShopContext.SaveChanges();
        }

        public async Task DeleteAsync(AddedByStatusModel addedByStatus)
        {
            _gameShopContext.AddedByStatus.Remove(addedByStatus);
            await _gameShopContext.SaveChangesAsync();
        }

        public IEnumerable<AddedByStatusModel> GetAll()
        {
            return _gameShopContext.AddedByStatus.ToList();
        }

        public async Task<IEnumerable<AddedByStatusModel>> GetAllAsync()
        {
            return await _gameShopContext.AddedByStatus.ToListAsync();
        }

        public AddedByStatusModel GetById(int id)
        {
            return _gameShopContext.AddedByStatus.Find(id);
        }

        public async Task<AddedByStatusModel> GetByIdAsync(int id)
        {
            return await _gameShopContext.AddedByStatus.FindAsync(id);
        }

        public void Update(AddedByStatusModel addedByStatus)
        {
            _gameShopContext.Update(addedByStatus);
            _gameShopContext.SaveChanges();
        }

        public async Task UpdateAsync(AddedByStatusModel addedByStatus)
        {
            _gameShopContext.Update(addedByStatus);
            await _gameShopContext.SaveChangesAsync();
        }
    }
}
