using Infrastructure.Models.Rating;

namespace ServicesLayer.Services.Interfaces
{
    public interface IRatingModelService
    {
        void Add(RatingModel model);
        Task AddAsync(RatingModel model);
        void Delete(RatingModel model);
        Task DeleteAsync(RatingModel model);
        void Update(RatingModel model);
        Task UpdateAsync(RatingModel model);
        RatingModel GetById(int id);
        Task<RatingModel> GetByIdAsync(int id);
        IEnumerable<RatingModel> GetAll();
        Task<IEnumerable<RatingModel>> GetAllAsync();
    }
}
