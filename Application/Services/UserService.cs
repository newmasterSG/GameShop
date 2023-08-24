using Application.InterfaceServices;
using Infrastructure.Context;
using Infrastructure.UnitOfWork.UnitOfWork;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly GameShopContext _dbContext;

        public UserService(GameShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsEmailVerified(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);
            return user != null && user.EmailConfirmed;
        }
    }
}
