using Infrastructure.Models.Store;

namespace Infrastructure.Repository.Interfaces
{
    public interface IStoreModelRepository
    {
        StoreModel GetById(int id);

        IEnumerable<StoreModel> GetAll();

        void Add(StoreModel model);

        void Delete(StoreModel StoreModel);

        void Update(StoreModel StoreModel);
        Task<StoreModel> GetByIdAsync(int id);

        Task<IEnumerable<StoreModel>> GetAllAsync();

        Task AddAsync(StoreModel model);

        Task DeleteAsync(StoreModel addedByStatus);

        Task UpdateAsync(StoreModel addedByStatus);
    }
}
