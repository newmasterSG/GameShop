using Infrastructure.Models.PlatformInfo;

namespace ServicesLayer.Services.Interfaces
{
    public interface IPlatformInfoModelService
    {
        void Add(PlatformInfoModel model);
        Task AddAsync(PlatformInfoModel model);
        void Delete(PlatformInfoModel model);
        Task DeleteAsync(PlatformInfoModel model);
        void Update(PlatformInfoModel model);
        Task UpdateAsync(PlatformInfoModel model);
        PlatformInfoModel GetById(int id);
        Task<PlatformInfoModel> GetByIdAsync(int id);
        IEnumerable<PlatformInfoModel> GetAll();
        Task<IEnumerable<PlatformInfoModel>> GetAllAsync();
    }
}
