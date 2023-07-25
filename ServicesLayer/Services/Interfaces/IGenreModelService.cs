using Infrastructure.Models.Genres;

namespace ServicesLayer.Services.Interfaces
{
    public interface IGenreModelService
    {
        void Add(GenreModel model);
        Task AddAsync(GenreModel model);
        void Delete(GenreModel model);
        Task DeleteAsync(GenreModel model);
        void Update(GenreModel model);
        Task UpdateAsync(GenreModel model);
        GenreModel GetById(int id);
        Task<GenreModel> GetByIdAsync(int id);
        IEnumerable<GenreModel> GetAll();
        Task<IEnumerable<GenreModel>> GetAllAsync();
    }
}
