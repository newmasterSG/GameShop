using Infrastructure.Models.AddedByStatus;
using Infrastructure.Models.StoreInfo;

namespace Infrastructure.Repository.Interfaces
{
    public interface IStoreInfoModelRepository
    {
        StoreInfoModel GetById(int id);

        IEnumerable<StoreInfoModel> GetAll();

        void Add(StoreInfoModel model);

        void Delete(StoreInfoModel storeInfo);

        void Update(StoreInfoModel storeInfo);
        Task<StoreInfoModel> GetByIdAsync(int id);

        Task<IEnumerable<StoreInfoModel>> GetAllAsync();

        Task AddAsync(StoreInfoModel model);

        Task DeleteAsync(StoreInfoModel storeInfo);

        Task UpdateAsync(StoreInfoModel storeInfo);
    }
}
