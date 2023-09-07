using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.User
{
    public class UserEntity : IdentityUser
    {
        public DateTime DateRegistration { get; set; }

        public int GameOwning { get; set; }

        public ICollection<ReviewEntity> Reviews { get; set; }

        public ICollection<MessageEntity> Messages { get; set; }
    }
}
