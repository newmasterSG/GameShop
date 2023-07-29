using Infrastructure.Models.Developer;

namespace ServicesLayer.Services.Interfaces
{
    public interface IDevelopersModelService
    {
        void Add(DevelopersModel model);
        Task AddAsync(DevelopersModel model);
        void Delete(DevelopersModel model);
        Task DeleteAsync(DevelopersModel model);
        void Update(DevelopersModel model);
        Task UpdateAsync(DevelopersModel model);
        DevelopersModel GetById(int id);
        Task<DevelopersModel> GetByIdAsync(int id);
        IEnumerable<DevelopersModel> GetAll();
        Task<IEnumerable<DevelopersModel>> GetAllAsync();
    }
}
