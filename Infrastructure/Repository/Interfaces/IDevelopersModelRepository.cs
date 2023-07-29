using Infrastructure.Models.Developer;

namespace Infrastructure.Repository.Interfaces
{
    public interface IDevelopersModelRepository
    {
        DevelopersModel GetById(int id);

        IEnumerable<DevelopersModel> GetAll();

        void Add(DevelopersModel model);

        void Delete(DevelopersModel addedByStatus);

        void Update(DevelopersModel addedByStatus);
        Task<DevelopersModel> GetByIdAsync(int id);

        Task<IEnumerable<DevelopersModel>> GetAllAsync();

        Task AddAsync(DevelopersModel model);

        Task DeleteAsync(DevelopersModel addedByStatus);

        Task UpdateAsync(DevelopersModel addedByStatus);
    }
}
