using Infrastructure.Models.AddedByStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface IAddedByStatusModelService
    {
        void Add(AddedByStatusModel model);
        Task AddAsync(AddedByStatusModel model);
        void Delete(AddedByStatusModel model);
        Task DeleteAsync(AddedByStatusModel model);
        void Update(AddedByStatusModel model);
        Task UpdateAsync(AddedByStatusModel model);
        AddedByStatusModel GetById(int id);
        Task<AddedByStatusModel> GetByIdAsync(int id);
        IEnumerable<AddedByStatusModel> GetAll();
        Task<IEnumerable<AddedByStatusModel>> GetAllAsync();
    }
}
