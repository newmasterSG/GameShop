using Application.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserDecorator : IUserService
    {
        private readonly IUserService _userService;

        public UserDecorator(IUserService userService)
        {
            _userService = userService;
        }

        public bool IsEmailVerified(string username)
        {
           return _userService.IsEmailVerified(username);
        }
    }
}
