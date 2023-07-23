using Infrastructure.Models.Tags;

namespace Infrastructure.Repository.Interfaces
{
    public interface ITagModelRepository
    {
        TagModel GetById(int id);

        IEnumerable<TagModel> GetAll();

        void Add(TagModel model);

        void Delete(TagModel tag);

        void Update(TagModel tag);
        Task<TagModel> GetByIdAsync(int id);

        Task<IEnumerable<TagModel>> GetAllAsync();

        Task AddAsync(TagModel model);

        Task DeleteAsync(TagModel tag);

        Task UpdateAsync(TagModel tag);
    }
}
