using Infrastructure.Models.ShortScreenshot;

namespace Infrastructure.Repository.Interfaces
{
    public interface IShortScreenshotModelRepository
    {
        ShortScreenshotModel GetById(int id);

        IEnumerable<ShortScreenshotModel> GetAll();

        void Add(ShortScreenshotModel model);

        void Delete(ShortScreenshotModel shortScreenshot);

        void Update(ShortScreenshotModel shortScreenshot);
        Task<ShortScreenshotModel> GetByIdAsync(int id);

        Task<IEnumerable<ShortScreenshotModel>> GetAllAsync();

        Task AddAsync(ShortScreenshotModel model);

        Task DeleteAsync(ShortScreenshotModel shortScreenshot);

        Task UpdateAsync(ShortScreenshotModel shortScreenshot);
    }
}
