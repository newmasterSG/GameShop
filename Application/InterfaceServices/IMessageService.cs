using Domain.Entities;

namespace Application.InterfaceServices
{
    public interface IMessageService
    {
        Task AddMessage(string userId, string message);
        Task SendAdminReply(string userId, string adminReply);
        Task<IEnumerable<MessageEntity>> GetUserMessages();
    }
}