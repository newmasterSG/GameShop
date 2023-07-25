using Infrastructure.Models.ShortScreenshot;

namespace ServicesLayer.Services.Interfaces
{
    public interface IShortScreenshotModelService
    {
        void Add(ShortScreenshotModel model);
        Task AddAsync(ShortScreenshotModel model);
        void Delete(ShortScreenshotModel model);
        Task DeleteAsync(ShortScreenshotModel model);
        void Update(ShortScreenshotModel model);
        Task UpdateAsync(ShortScreenshotModel model);
        ShortScreenshotModel GetById(int id);
        Task<ShortScreenshotModel> GetByIdAsync(int id);
        IEnumerable<ShortScreenshotModel> GetAll();
        Task<IEnumerable<ShortScreenshotModel>> GetAllAsync();
    }
}
