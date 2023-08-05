using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using GameStore.Application.Services.Interfaces;
using System.Linq.Expressions;

namespace GameStore.Application.Services.Service
{
    public class Services<T> : IServices<T> where T : EntityBase, new()
    {
        private readonly IRepository<T> _repository;
        
        public Services(IRepository<T> repository)
        {
            _repository = repository;
        }
        
        public virtual void Add(T model)
        {
            _repository.Insert(model);
        }

        public virtual async Task AddAsync(T model)
        {
            await _repository.InsertAsync(model);
        }

        public virtual void Delete(T model)
        {
            _repository.Delete(model);
        }

        public virtual async Task DeleteAsync(T model)
        {
            await _repository.DeleteAsync(model);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _repository.List(predicate);
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.ListAsync(predicate);
        }

        public virtual void Update(T model)
        {
            _repository.Update(model);
        }

        public virtual async Task UpdateAsync(T model)
        {
            await _repository.UpdateAsync(model);
        }
    }
}
