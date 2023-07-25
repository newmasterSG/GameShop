using Infrastructure.Models.ESRBRating;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class ESRBRatingModelService : IESRBRatingModelService
    {
        private readonly IESRBRatingModelRepository _eSRBRatingModelRepository;
        public ESRBRatingModelService(IESRBRatingModelRepository eSRBRatingModelRepository)
        {
            _eSRBRatingModelRepository = eSRBRatingModelRepository;
        }

        public void Add(ESRBRatingModel model)
        {
            _eSRBRatingModelRepository.Add(model);
        }

        public async Task AddAsync(ESRBRatingModel model)
        {
            await _eSRBRatingModelRepository.AddAsync(model);
        }

        public void Delete(ESRBRatingModel model)
        {
            _eSRBRatingModelRepository.Delete(model);
        }

        public async Task DeleteAsync(ESRBRatingModel model)
        {
            await _eSRBRatingModelRepository.DeleteAsync(model);
        }

        public IEnumerable<ESRBRatingModel> GetAll()
        {
            return _eSRBRatingModelRepository.GetAll();
        }

        public async Task<IEnumerable<ESRBRatingModel>> GetAllAsync()
        {
            return await _eSRBRatingModelRepository.GetAllAsync();
        }

        public ESRBRatingModel GetById(int id)
        {
            return _eSRBRatingModelRepository.GetById(id);
        }

        public async Task<ESRBRatingModel> GetByIdAsync(int id)
        {
            return await _eSRBRatingModelRepository.GetByIdAsync(id);
        }

        public void Update(ESRBRatingModel model)
        {
            _eSRBRatingModelRepository.Update(model);
        }

        public async Task UpdateAsync(ESRBRatingModel model)
        {
            await _eSRBRatingModelRepository.UpdateAsync(model);
        }
    }
}
