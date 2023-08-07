using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HomeService<T> where T : EntityBase, new()
    {
        private readonly IRepository<T> _repository;
        public HomeService(IRepository<T> repository)
        {
            _repository = repository;
        }

        
    }
}
