using Infrastructure.Models.ESRBRating;

namespace Infrastructure.Repository.Interfaces
{
    public interface IESRBRatingModelRepository
    {
        ESRBRatingModel GetById(int id);

        IEnumerable<ESRBRatingModel> GetAll();

        void Add(ESRBRatingModel model);

        void Delete(ESRBRatingModel addedByStatus);

        void Update(ESRBRatingModel addedByStatus);
        Task<ESRBRatingModel> GetByIdAsync(int id);

        Task<IEnumerable<ESRBRatingModel>> GetAllAsync();

        Task AddAsync(ESRBRatingModel model);

        Task DeleteAsync(ESRBRatingModel addedByStatus);

        Task UpdateAsync(ESRBRatingModel addedByStatus);
    }
}
