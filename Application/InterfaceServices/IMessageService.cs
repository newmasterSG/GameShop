using Domain.Entities;

namespace Application.InterfaceServices
{
    public interface IMessageService
    {
        Task AddMessageAsync(string userId, string message);
        Task SendAdminReplyAsync(string userId, string adminReply);
        Task<IEnumerable<MessageEntity>> GetUserMessagesAsync();
    }
}