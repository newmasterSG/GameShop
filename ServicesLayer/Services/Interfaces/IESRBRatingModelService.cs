using Infrastructure.Models.ESRBRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface IESRBRatingModelService
    {
        void Add(ESRBRatingModel model);
        Task AddAsync(ESRBRatingModel model);
        void Delete(ESRBRatingModel model);
        Task DeleteAsync(ESRBRatingModel model);
        void Update(ESRBRatingModel model);
        Task UpdateAsync(ESRBRatingModel model);
        ESRBRatingModel GetById(int id);
        Task<ESRBRatingModel> GetByIdAsync(int id);
        IEnumerable<ESRBRatingModel> GetAll();
        Task<IEnumerable<ESRBRatingModel>> GetAllAsync();
    }
}
