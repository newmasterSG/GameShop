using Infrastructure.Models.Tags;
using Infrastructure.Repository.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class TagModelService
    {
        private readonly ITagModelRepository _tagModelRepository;
        public TagModelService(ITagModelRepository tagModelRepository)
        {
            _tagModelRepository = tagModelRepository;
        }

        public void Add(TagModel model)
        {
            _tagModelRepository.Add(model);
        }

        public async Task AddAsync(TagModel model)
        {
            await _tagModelRepository.AddAsync(model);
        }

        public void Delete(TagModel model)
        {
            _tagModelRepository.Delete(model);
        }

        public async Task DeleteAsync(TagModel model)
        {
            await _tagModelRepository.DeleteAsync(model);
        }

        public IEnumerable<TagModel> GetAll()
        {
            return _tagModelRepository.GetAll();
        }

        public async Task<IEnumerable<TagModel>> GetAllAsync()
        {
            return await _tagModelRepository.GetAllAsync();
        }

        public TagModel GetById(int id)
        {
            return _tagModelRepository.GetById(id);
        }

        public async Task<TagModel> GetByIdAsync(int id)
        {
            return await _tagModelRepository.GetByIdAsync(id);
        }

        public void Update(TagModel model)
        {
            _tagModelRepository.Update(model);
        }

        public async Task UpdateAsync(TagModel model)
        {
            await _tagModelRepository.UpdateAsync(model);
        }
    }
}
