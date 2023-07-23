using Infrastructure.Models.Genres;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGenreModelRepository
    {
        GenreModel GetById(int id);

        IEnumerable<GenreModel> GetAll();

        void Add(GenreModel model);

        void Delete(GenreModel addedByStatus);

        void Update(GenreModel addedByStatus);
        Task<GenreModel> GetByIdAsync(int id);

        Task<IEnumerable<GenreModel>> GetAllAsync();

        Task AddAsync(GenreModel model);

        Task DeleteAsync(GenreModel addedByStatus);

        Task UpdateAsync(GenreModel addedByStatus);
    }
}
