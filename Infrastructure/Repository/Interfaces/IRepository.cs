using Domain.Entities;
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
        IEnumerable<T> Take(int skipElements, int takeElements);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> TakeAsync(int skipElements, int takeElements);
    }
}
