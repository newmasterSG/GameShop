using Infrastructure.Models.PlatformInfo;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class PlatformInfoModelService: IPlatformInfoModelService
    {
        private readonly IPlatformInfoModelRepository _platformInfoModelRepository;
        public PlatformInfoModelService(IPlatformInfoModelRepository platformInfoModelRepository)
        {
            _platformInfoModelRepository = platformInfoModelRepository;
        }

        public void Add(PlatformInfoModel model)
        {
            _platformInfoModelRepository.Add(model);
        }

        public async Task AddAsync(PlatformInfoModel model)
        {
            await _platformInfoModelRepository.AddAsync(model);
        }

        public void Delete(PlatformInfoModel model)
        {
            _platformInfoModelRepository.Delete(model);
        }

        public async Task DeleteAsync(PlatformInfoModel model)
        {
            await _platformInfoModelRepository.DeleteAsync(model);
        }

        public IEnumerable<PlatformInfoModel> GetAll()
        {
            return _platformInfoModelRepository.GetAll();
        }

        public async Task<IEnumerable<PlatformInfoModel>> GetAllAsync()
        {
            return await _platformInfoModelRepository.GetAllAsync();
        }

        public PlatformInfoModel GetById(int id)
        {
            return _platformInfoModelRepository.GetById(id);
        }

        public async Task<PlatformInfoModel> GetByIdAsync(int id)
        {
            return await _platformInfoModelRepository.GetByIdAsync(id);
        }

        public void Update(PlatformInfoModel model)
        {
            _platformInfoModelRepository.Update(model);
        }

        public async Task UpdateAsync(PlatformInfoModel model)
        {
            await _platformInfoModelRepository.UpdateAsync(model);
        }
    }
}
