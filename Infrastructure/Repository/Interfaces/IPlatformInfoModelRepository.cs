using Infrastructure.Models.PlatformInfo;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPlatformInfoModelRepository
    {
        PlatformInfoModel GetById(int id);

        IEnumerable<PlatformInfoModel> GetAll();

        void Add(PlatformInfoModel model);

        void Delete(PlatformInfoModel addedByStatus);

        void Update(PlatformInfoModel addedByStatus);
        Task<PlatformInfoModel> GetByIdAsync(int id);

        Task<IEnumerable<PlatformInfoModel>> GetAllAsync();

        Task AddAsync(PlatformInfoModel model);

        Task DeleteAsync(PlatformInfoModel addedByStatus);

        Task UpdateAsync(PlatformInfoModel addedByStatus);
    }
}
