using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceServices
{
    public interface IUserService
    {
        bool IsEmailVerified(string username);
    }
}
