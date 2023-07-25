using Infrastructure.Models.Platform;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class PlatformModelService: IPlatformModelService
    {
        private readonly IPlatformModelRepository _platformModelRepository;
        public PlatformModelService(IPlatformModelRepository platformModelRepository)
        {
            _platformModelRepository = platformModelRepository;
        }

        public void Add(PlatformModel model)
        {
            _platformModelRepository.Add(model);
        }

        public async Task AddAsync(PlatformModel model)
        {
            await _platformModelRepository.AddAsync(model);
        }

        public void Delete(PlatformModel model)
        {
            _platformModelRepository.Delete(model);
        }

        public async Task DeleteAsync(PlatformModel model)
        {
            await _platformModelRepository.DeleteAsync(model);
        }

        public IEnumerable<PlatformModel> GetAll()
        {
            return _platformModelRepository.GetAll();
        }

        public async Task<IEnumerable<PlatformModel>> GetAllAsync()
        {
            return await _platformModelRepository.GetAllAsync();
        }

        public PlatformModel GetById(int id)
        {
            return _platformModelRepository.GetById(id);
        }

        public async Task<PlatformModel> GetByIdAsync(int id)
        {
            return await _platformModelRepository.GetByIdAsync(id);
        }

        public void Update(PlatformModel model)
        {
            _platformModelRepository.Update(model);
        }

        public async Task UpdateAsync(PlatformModel model)
        {
            await _platformModelRepository.UpdateAsync(model);
        }
    }
}
