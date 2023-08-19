using Microsoft.AspNetCore.Identity;

namespace Infrastructure.User
{
    public class UserModel : IdentityUser
    {
        public DateTime DateRegistration { get; set; }

        public int GameOwning { get; set; }
    }
}
