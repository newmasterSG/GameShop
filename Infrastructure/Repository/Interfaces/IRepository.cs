using Domain.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces
{
    public interface IRepository<T> where T : EntityBase, new()
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
    }
}
