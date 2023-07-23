using Infrastructure.Models.AddedByStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IAddedByStatusModelRepositoty
    {
        AddedByStatusModel GetById(int id);

        IEnumerable<AddedByStatusModel> GetAll();

        void Add(AddedByStatusModel model);

        void Delete(AddedByStatusModel addedByStatus);

        void Update(AddedByStatusModel addedByStatus);
        Task<AddedByStatusModel> GetByIdAsync(int id);

        Task<IEnumerable<AddedByStatusModel>> GetAllAsync();

        Task AddAsync(AddedByStatusModel model);

        Task DeleteAsync(AddedByStatusModel addedByStatus);

        Task UpdateAsync(AddedByStatusModel addedByStatus);
    }
}
