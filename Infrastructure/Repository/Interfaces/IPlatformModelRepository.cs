using Infrastructure.Models.Platform;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPlatformModelRepository
    {
        PlatformModel GetById(int id);

        IEnumerable<PlatformModel> GetAll();

        void Add(PlatformModel model);

        void Delete(PlatformModel addedByStatus);

        void Update(PlatformModel addedByStatus);

        Task<PlatformModel> GetByIdAsync(int id);

        Task<IEnumerable<PlatformModel>> GetAllAsync();

        Task AddAsync(PlatformModel model);

        Task DeleteAsync(PlatformModel addedByStatus);

        Task UpdateAsync(PlatformModel addedByStatus);
    }
}
