using Application.InterfaceServices;
using Microsoft.AspNetCore.SignalR;

namespace UI.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageService _messageService;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IAdminService _adminService;

        public ChatHub(IMessageService messageService,
            IHubContext<ChatHub> hubContext,
            IAdminService adminService) 
        { 
            _messageService = messageService;
            _hubContext = hubContext;
            _adminService = adminService;
        }
        public async Task SendMessage(string user, string message)
        {
            var userReal = "User";
            if (!string.IsNullOrEmpty(user) && !user.Equals("User"))
            {
                userReal = Context.User?.Claims.FirstOrDefault(e => e.Value == user)?
                .Subject?.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                await _messageService.AddMessageAsync(user, message);
            }

            await SendToAllAdmins(userReal, message, Context.User?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);
        }

        public async Task SendAdminReply(string userId, string adminReply)
        {
            // Admin sends a reply to a specific user.
            await _messageService.SendAdminReplyAsync(userId, adminReply);

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

        private async Task SendToAllAdmins(string userReal, string message, string userId)
        {
            var admins = await _adminService.GetAllAdminAsync();

            foreach (var admin in admins)
            {
                await Clients.User(admin.Id).SendAsync("ReceiveMessage", userReal, message, userId);
            }
        }
    }
}
