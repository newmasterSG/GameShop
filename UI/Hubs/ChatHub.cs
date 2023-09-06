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

            if (!string.IsNullOrEmpty(user) && !user.Equals("User"))
            {
                await _messageService.AddMessage(user, message);
                await Clients.User(Context.User.Claims.FirstOrDefault(c => c.Type == "sub").Value).SendAsync("ReceiveMessage", user, message);
                await Task.CompletedTask;
            }

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendAdminReply(string userId, string adminReply)
        {
            // Admin sends a reply to a specific user.
            await _messageService.SendAdminReply(userId, adminReply);

            // Send the admin reply to the specific user. Not Worked
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
