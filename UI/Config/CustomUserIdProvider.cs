using Microsoft.AspNetCore.SignalR;

namespace UI.Config
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Claims?.FirstOrDefault(c => c?.Type == "sub")?.Value;
        }
    }
}
