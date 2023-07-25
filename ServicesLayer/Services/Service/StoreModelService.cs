using Infrastructure.Models.Store;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class StoreModelService : IStoreModelService
    {
        private readonly IStoreModelRepository _storeModelRepository;
        public StoreModelService(IStoreModelRepository storeModelRepository)
        {
            _storeModelRepository = storeModelRepository;
        }

        public void Add(StoreModel model)
        {
            _storeModelRepository.Add(model);
        }

        public async Task AddAsync(StoreModel model)
        {
            await _storeModelRepository.AddAsync(model);
        }

        public void Delete(StoreModel model)
        {
            _storeModelRepository.Delete(model);
        }

        public async Task DeleteAsync(StoreModel model)
        {
            await _storeModelRepository.DeleteAsync(model);
        }

        public IEnumerable<StoreModel> GetAll()
        {
            return _storeModelRepository.GetAll();
        }

        public async Task<IEnumerable<StoreModel>> GetAllAsync()
        {
            return await _storeModelRepository.GetAllAsync();
        }

        public StoreModel GetById(int id)
        {
            return _storeModelRepository.GetById(id);
        }

        public async Task<StoreModel> GetByIdAsync(int id)
        {
            return await _storeModelRepository.GetByIdAsync(id);
        }

        public void Update(StoreModel model)
        {
            _storeModelRepository.Update(model);
        }

        public async Task UpdateAsync(StoreModel model)
        {
            await _storeModelRepository.UpdateAsync(model);
        }
    }
}
