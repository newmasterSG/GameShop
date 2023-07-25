using Infrastructure.Models.Tags;

namespace ServicesLayer.Services.Interfaces
{
    public interface ITagModelService
    {
        void Add(TagModel model);
        Task AddAsync(TagModel model);
        void Delete(TagModel model);
        Task DeleteAsync(TagModel model);
        void Update(TagModel model);
        Task UpdateAsync(TagModel model);
        TagModel GetById(int id);
        Task<TagModel> GetByIdAsync(int id);
        IEnumerable<TagModel> GetAll();
        Task<IEnumerable<TagModel>> GetAllAsync();
    }
}
