using Infrastructure.Models.Genres;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class GenreModelService : IGenreModelService
    {
        private readonly IGenreModelRepository _genreModelRepository;
        public GenreModelService(IGenreModelRepository genreModelRepository)
        {
            _genreModelRepository = genreModelRepository;
        }

        public void Add(GenreModel model)
        {
            _genreModelRepository.Add(model);
        }

        public async Task AddAsync(GenreModel model)
        {
            await _genreModelRepository.AddAsync(model);
        }

        public void Delete(GenreModel model)
        {
            _genreModelRepository.Delete(model);
        }

        public async Task DeleteAsync(GenreModel model)
        {
            await _genreModelRepository.DeleteAsync(model);
        }

        public IEnumerable<GenreModel> GetAll()
        {
            return _genreModelRepository.GetAll();
        }

        public async Task<IEnumerable<GenreModel>> GetAllAsync()
        {
            return await _genreModelRepository.GetAllAsync();
        }

        public GenreModel GetById(int id)
        {
            return _genreModelRepository.GetById(id);
        }

        public async Task<GenreModel> GetByIdAsync(int id)
        {
            return await _genreModelRepository.GetByIdAsync(id);
        }

        public void Update(GenreModel model)
        {
            _genreModelRepository.Update(model);
        }

        public async Task UpdateAsync(GenreModel model)
        {
            await _genreModelRepository.UpdateAsync(model);
        }
    }
}
