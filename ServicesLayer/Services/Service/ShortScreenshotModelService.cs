using Infrastructure.Models.ShortScreenshot;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class ShortScreenshotModelService : IShortScreenshotModelService
    {
        private readonly IShortScreenshotModelRepository _shortScreenshotModelRepository;
        public ShortScreenshotModelService(IShortScreenshotModelRepository shortScreenshotModelRepository)
        {
            _shortScreenshotModelRepository = shortScreenshotModelRepository;
        }

        public void Add(ShortScreenshotModel model)
        {
            _shortScreenshotModelRepository.Add(model);
        }

        public async Task AddAsync(ShortScreenshotModel model)
        {
            await _shortScreenshotModelRepository.AddAsync(model);
        }

        public void Delete(ShortScreenshotModel model)
        {
            _shortScreenshotModelRepository.Delete(model);
        }

        public async Task DeleteAsync(ShortScreenshotModel model)
        {
            await _shortScreenshotModelRepository.DeleteAsync(model);
        }

        public IEnumerable<ShortScreenshotModel> GetAll()
        {
            return _shortScreenshotModelRepository.GetAll();
        }

        public async Task<IEnumerable<ShortScreenshotModel>> GetAllAsync()
        {
            return await _shortScreenshotModelRepository.GetAllAsync();
        }

        public ShortScreenshotModel GetById(int id)
        {
            return _shortScreenshotModelRepository.GetById(id);
        }

        public async Task<ShortScreenshotModel> GetByIdAsync(int id)
        {
            return await _shortScreenshotModelRepository.GetByIdAsync(id);
        }

        public void Update(ShortScreenshotModel model)
        {
            _shortScreenshotModelRepository.Update(model);
        }

        public async Task UpdateAsync(ShortScreenshotModel model)
        {
            await _shortScreenshotModelRepository.UpdateAsync(model);
        }
    }
}
