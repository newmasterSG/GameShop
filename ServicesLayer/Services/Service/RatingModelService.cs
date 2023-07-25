using Infrastructure.Models.Rating;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class RatingModelService : IRatingModelService
    {
        private readonly IRatingModelRepository _ratingModelRepository;
        public RatingModelService(IRatingModelRepository ratingModelRepository)
        {
            _ratingModelRepository = ratingModelRepository;
        }

        public void Add(RatingModel model)
        {
            _ratingModelRepository.Add(model);
        }

        public async Task AddAsync(RatingModel model)
        {
            await _ratingModelRepository.AddAsync(model);
        }

        public void Delete(RatingModel model)
        {
            _ratingModelRepository.Delete(model);
        }

        public async Task DeleteAsync(RatingModel model)
        {
            await _ratingModelRepository.DeleteAsync(model);
        }

        public IEnumerable<RatingModel> GetAll()
        {
            return _ratingModelRepository.GetAll();
        }

        public async Task<IEnumerable<RatingModel>> GetAllAsync()
        {
            return await _ratingModelRepository.GetAllAsync();
        }

        public RatingModel GetById(int id)
        {
            return _ratingModelRepository.GetById(id);
        }

        public async Task<RatingModel> GetByIdAsync(int id)
        {
            return await _ratingModelRepository.GetByIdAsync(id);
        }

        public void Update(RatingModel model)
        {
            _ratingModelRepository.Update(model);
        }

        public async Task UpdateAsync(RatingModel model)
        {
            await _ratingModelRepository.UpdateAsync(model);
        }
    }
}
