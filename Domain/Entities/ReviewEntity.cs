using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public string UserId { get; set; }
        public UserEntity User { get; set; }

        public int GameId { get; set; }
        public GamesEntity Game { get; set; }
    }
}
