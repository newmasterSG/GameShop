using Application.InterfaceServices;
using Domain.Entities;
using Domain.Interfaces;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _context;
        public MessageService(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }

        public async Task AddMessage(string userId, string message)
        {
            var user = _context.GetRepository<UserEntity>().Find(e => e.Id.Equals(userId));

            if (user != null)
            {
                await _context.GetRepository<MessageEntity>().InsertAsync(new MessageEntity
                {
                    User = user,
                    Message = message,
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task SendAdminReply(string userId, string adminReply)
        {
            // Implement logic to send an admin reply to a user.
            // Set the IsAnswered flag and save the message.
            var user = _context.GetRepository<UserEntity>().Find(u => u.Id == userId);

            if (user != null)
            {
                var message = new MessageEntity
                {
                    User = user,
                    Message = adminReply,
                    IsAnswered = true,
                };

                await _context.GetRepository<MessageEntity>().InsertAsync(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MessageEntity>> GetUserMessages()
        {
            // Implement logic to retrieve user messages from the database.
            // Replace the following line with your actual implementation.
            return await _context.GetRepository<MessageEntity>().GetAllAsync();
        }
    }
}
