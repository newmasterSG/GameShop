using Infrastructure.Models.AddedByStatus;
using Infrastructure.Repository.Interfaces;
using ServicesLayer.Services.Interfaces;

namespace ServicesLayer.Services.Service
{
    public class AddedByStatusModelService : IAddedByStatusModelService
    {
        private readonly IAddedByStatusModelRepositoty _addedByStatusRepositoty;
        public AddedByStatusModelService(IAddedByStatusModelRepositoty addedByStatusRepositoty)
        {
            _addedByStatusRepositoty = addedByStatusRepositoty;
        }

        public void Add(AddedByStatusModel model)
        {
            _addedByStatusRepositoty.Add(model);
        }

        public async Task AddAsync(AddedByStatusModel model)
        {
            await _addedByStatusRepositoty.AddAsync(model);
        }

        public void Delete(AddedByStatusModel model)
        {
            _addedByStatusRepositoty.Delete(model);
        }

        public async Task DeleteAsync(AddedByStatusModel model)
        {
            await _addedByStatusRepositoty.DeleteAsync(model);
        }

        public IEnumerable<AddedByStatusModel> GetAll()
        {
            return _addedByStatusRepositoty.GetAll();
        }

        public async Task<IEnumerable<AddedByStatusModel>> GetAllAsync()
        {
            return await _addedByStatusRepositoty.GetAllAsync();
        }

        public AddedByStatusModel GetById(int id)
        {
            return _addedByStatusRepositoty.GetById(id);
        }

        public async Task<AddedByStatusModel> GetByIdAsync(int id)
        {
            return await _addedByStatusRepositoty.GetByIdAsync(id);
        }

        public void Update(AddedByStatusModel model)
        {
            _addedByStatusRepositoty.Update(model);
        }

        public async Task UpdateAsync(AddedByStatusModel model)
        {
            await _addedByStatusRepositoty.UpdateAsync(model);
        }
    }
}
