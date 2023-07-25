using Infrastructure.Models.StoreInfo;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class StoreInfoModelService: IStoreInfoModelService
    {
        private readonly IStoreInfoModelRepository _storeInfoModelRepository;
        public StoreInfoModelService(IStoreInfoModelRepository storeInfoModelRepository)
        {
            _storeInfoModelRepository = storeInfoModelRepository;
        }

        public void Add(StoreInfoModel model)
        {
            _storeInfoModelRepository.Add(model);
        }

        public async Task AddAsync(StoreInfoModel model)
        {
            await _storeInfoModelRepository.AddAsync(model);
        }

        public void Delete(StoreInfoModel model)
        {
            _storeInfoModelRepository.Delete(model);
        }

        public async Task DeleteAsync(StoreInfoModel model)
        {
            await _storeInfoModelRepository.DeleteAsync(model);
        }

        public IEnumerable<StoreInfoModel> GetAll()
        {
            return _storeInfoModelRepository.GetAll();
        }

        public async Task<IEnumerable<StoreInfoModel>> GetAllAsync()
        {
            return await _storeInfoModelRepository.GetAllAsync();
        }

        public StoreInfoModel GetById(int id)
        {
            return _storeInfoModelRepository.GetById(id);
        }

        public async Task<StoreInfoModel> GetByIdAsync(int id)
        {
            return await _storeInfoModelRepository.GetByIdAsync(id);
        }

        public void Update(StoreInfoModel model)
        {
            _storeInfoModelRepository.Update(model);
        }

        public async Task UpdateAsync(StoreInfoModel model)
        {
            await _storeInfoModelRepository.UpdateAsync(model);
        }
    }
}
