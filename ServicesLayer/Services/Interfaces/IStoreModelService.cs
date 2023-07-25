using Infrastructure.Models.Store;

namespace ServicesLayer.Services.Interfaces
{
    public interface IStoreModelService
    {
        void Add(StoreModel model);
        Task AddAsync(StoreModel model);
        void Delete(StoreModel model);
        Task DeleteAsync(StoreModel model);
        void Update(StoreModel model);
        Task UpdateAsync(StoreModel model);
        StoreModel GetById(int id);
        Task<StoreModel> GetByIdAsync(int id);
        IEnumerable<StoreModel> GetAll();
        Task<IEnumerable<StoreModel>> GetAllAsync();
    }
}
