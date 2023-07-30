using Infrastructure.Models;
using System.Linq.Expressions;

namespace ServicesLayer.Services.Interfaces
{
    public interface IServices<T> where T : EntityBase, new()
    {
        void Add(T model);
        Task AddAsync(T model);
        void Delete(T model);
        Task DeleteAsync(T model);
        void Update(T model);
        Task UpdateAsync(T model);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
    }
}
