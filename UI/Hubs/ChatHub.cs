using Application.InterfaceServices;
using Microsoft.AspNetCore.SignalR;

namespace UI.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageService _messageService;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatHub(IMessageService messageService,
            IHubContext<ChatHub> hubContext) 
        { 
            _messageService = messageService;
            _hubContext = hubContext;
        }
        public async Task SendMessage(string user, string message)
        {
            var adminId = "56c3b0d4-f715-42fc-9f57-d8cd31910372";
            var userReal = "Users";
            if (!string.IsNullOrEmpty(user) && !user.Equals("User"))
            {
                userReal = Context.User?.Claims.FirstOrDefault(e => e.Value == user)?
                .Subject?.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                await _messageService.AddMessage(user, message);
            }

            await Clients.User(adminId).SendAsync("ReceiveMessage", userReal, message);
        }

        public async Task SendAdminReply(string userId, string adminReply)
        {
            // Admin sends a reply to a specific user.
            await _messageService.SendAdminReply(userId, adminReply);

            await Clients.User(userId).SendAsync("ReceiveAdminReply", adminReply);
        }

        public override async Task OnConnectedAsync()
        {
            if (Context.User.IsInRole("Admin"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Admins");
            }

            await base.OnConnectedAsync();
        }
    }
}
