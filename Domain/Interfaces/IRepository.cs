using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> Take(int skipElements, int takeElements, (Expression<Func<T, object>> expression, bool ascending) sortOrder);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> TakeAsync(int skipElements, 
            int takeElements, 
            (Expression<Func<T, object>> expression, bool ascending) sortOrder);

        /// <summary>
        /// Order by
        /// </summary>
        IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate);

        /// <summary>
        /// Group by
        /// </summary>
        IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate);

        /// <summary>
        /// Remove range of given entities
        /// </summary>
        void RemoveRange(IEnumerable<T> entities);

        T Find(Expression<Func<T, bool>> match);

        IQueryable<T> SelectInclude<TProperty>(Expression<Func<T, TProperty>> expression);

        IQueryable<T> Where(Expression<Func<T, bool>> match);

        IQueryable<T> AsNoTracking();

        int Count();

    }
}
