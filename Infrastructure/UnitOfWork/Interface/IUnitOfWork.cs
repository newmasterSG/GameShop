using Infrastructure.Repository.Interfaces;

namespace Infrastructure.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        void Dispose();
        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
        void Save();
        Task SaveChangesAsync();
    }
}