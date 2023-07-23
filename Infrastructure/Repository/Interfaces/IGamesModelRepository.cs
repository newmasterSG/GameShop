using Infrastructure.Models.Games;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGamesModelRepository
    {
        GamesModel GetById(int id);

        IEnumerable<GamesModel> GetAll();

        void Add(GamesModel model);

        void Delete(GamesModel addedByStatus);

        void Update(GamesModel addedByStatus);
        Task<GamesModel> GetByIdAsync(int id);

        Task<IEnumerable<GamesModel>> GetAllAsync();

        Task AddAsync(GamesModel model);

        Task DeleteAsync(GamesModel addedByStatus);

        Task UpdateAsync(GamesModel addedByStatus);
    }
}
