using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }

        public UserEntity User { get; set; }

        public bool IsAnswered { get; set; }
    }
}
