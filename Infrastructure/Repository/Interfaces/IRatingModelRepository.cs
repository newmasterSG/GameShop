using Infrastructure.Models.Rating;

namespace Infrastructure.Repository.Interfaces
{
    public interface IRatingModelRepository
    {
        RatingModel GetById(int id);

        IEnumerable<RatingModel> GetAll();

        void Add(RatingModel model);

        void Delete(RatingModel addedByStatus);

        void Update(RatingModel addedByStatus);
        Task<RatingModel> GetByIdAsync(int id);

        Task<IEnumerable<RatingModel>> GetAllAsync();

        Task AddAsync(RatingModel model);

        Task DeleteAsync(RatingModel addedByStatus);

        Task UpdateAsync(RatingModel addedByStatus);
    }
}
