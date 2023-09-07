using Application.InterfaceServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UI.Hubs;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly IMessageService _messageService;
        public AdminController(IHubContext<ChatHub> chatHubContext,
            IMessageService messageService)
        {
            _chatHubContext = chatHubContext;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var userMessages = await _messageService.GetUserMessages();
            return View(userMessages.ToList());
        }
    }
}
