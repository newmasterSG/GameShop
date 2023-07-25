using Infrastructure.Models.StoreInfo;

namespace ServicesLayer.Services.Interfaces
{
    public interface IStoreInfoModelService
    {
        void Add(StoreInfoModel model);
        Task AddAsync(StoreInfoModel model);
        void Delete(StoreInfoModel model);
        Task DeleteAsync(StoreInfoModel model);
        void Update(StoreInfoModel model);
        Task UpdateAsync(StoreInfoModel model);
        StoreInfoModel GetById(int id);
        Task<StoreInfoModel> GetByIdAsync(int id);
        IEnumerable<StoreInfoModel> GetAll();
        Task<IEnumerable<StoreInfoModel>> GetAllAsync();
    }
}
