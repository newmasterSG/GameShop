using Infrastructure.Models.Games;

namespace ServicesLayer.Services.Interfaces
{
    public interface IGamesModelService
    {
        void Add(GamesModel model);
        Task AddAsync(GamesModel model);
        void Delete(GamesModel model);
        Task DeleteAsync(GamesModel model);
        void Update(GamesModel model);
        Task UpdateAsync(GamesModel model);
        GamesModel GetById(int id);
        Task<GamesModel> GetByIdAsync(int id);
        IEnumerable<GamesModel> GetAll();
        Task<IEnumerable<GamesModel>> GetAllAsync();
    }
}
