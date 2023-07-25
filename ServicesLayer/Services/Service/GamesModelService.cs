using Infrastructure.Models.Games;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class GamesModelService : IGamesModelService
    {
        private readonly IGamesModelRepository _gamesModelRepository;
        public GamesModelService(IGamesModelRepository gamesModelRepository)
        {
            _gamesModelRepository = gamesModelRepository;
        }

        public void Add(GamesModel model)
        {
            _gamesModelRepository.Add(model);
        }

        public async Task AddAsync(GamesModel model)
        {
            await _gamesModelRepository.AddAsync(model);
        }

        public void Delete(GamesModel model)
        {
            _gamesModelRepository.Delete(model);
        }

        public async Task DeleteAsync(GamesModel model)
        {
            await _gamesModelRepository.DeleteAsync(model);
        }

        public IEnumerable<GamesModel> GetAll()
        {
            return _gamesModelRepository.GetAll();
        }

        public async Task<IEnumerable<GamesModel>> GetAllAsync()
        {
            return await _gamesModelRepository.GetAllAsync();
        }

        public GamesModel GetById(int id)
        {
            return _gamesModelRepository.GetById(id);
        }

        public async Task<GamesModel> GetByIdAsync(int id)
        {
            return await _gamesModelRepository.GetByIdAsync(id);
        }

        public void Update(GamesModel model)
        {
            _gamesModelRepository.Update(model);
        }

        public async Task UpdateAsync(GamesModel model)
        {
            await _gamesModelRepository.UpdateAsync(model);
        }
    }
}
