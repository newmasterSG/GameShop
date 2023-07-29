using Infrastructure.Models.Developer;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class DevelopersModelService : IDevelopersModelService
    {
        private readonly IDevelopersModelRepository _developersModelRepository;
        public DevelopersModelService(IDevelopersModelRepository developersModelRepository)
        {
            _developersModelRepository = developersModelRepository;
        }

        public void Add(DevelopersModel model)
        {
            _developersModelRepository.Add(model);
        }

        public async Task AddAsync(DevelopersModel model)
        {
            await _developersModelRepository.AddAsync(model);
        }

        public void Delete(DevelopersModel model)
        {
            _developersModelRepository.Delete(model);
        }

        public async Task DeleteAsync(DevelopersModel model)
        {
            await _developersModelRepository.DeleteAsync(model);
        }

        public IEnumerable<DevelopersModel> GetAll()
        {
            return _developersModelRepository.GetAll();
        }

        public async Task<IEnumerable<DevelopersModel>> GetAllAsync()
        {
            return await _developersModelRepository.GetAllAsync();
        }

        public DevelopersModel GetById(int id)
        {
            return _developersModelRepository.GetById(id);
        }

        public async Task<DevelopersModel> GetByIdAsync(int id)
        {
            return await _developersModelRepository.GetByIdAsync(id);
        }

        public void Update(DevelopersModel model)
        {
            _developersModelRepository.Update(model);
        }

        public async Task UpdateAsync(DevelopersModel model)
        {
            await _developersModelRepository.UpdateAsync(model);
        }
    }
}
