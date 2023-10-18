using Application.DTO;
using Application.InterfaceServices;
using Application.Services;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace UI.Controllers
{
    [Authorize]
    public class MyOfficeController : Controller
    {
        private readonly ILogger<MyOfficeController> _logger;
        private readonly IOrderServices _orderServices;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        public MyOfficeController(IOrderServices orderServices, 
            ILogger<MyOfficeController> logger, 
            UserManager<UserEntity> userManager, 
            SignInManager<UserEntity> signInManager)
        {
            _orderServices = orderServices;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Card()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyGames(OrderDTO orderDTO, string userId, string price)
        {
            // Get the user, for example, through ASP.NET Identity
            var user = await _userManager.FindByIdAsync(userId);

            decimal prices;
            CultureInfo culture = CultureInfo.InvariantCulture;
            if (Decimal.TryParse(price, NumberStyles.Any, culture, out prices))
            {
                try
                {
                    _orderServices.CreateOrder(user, orderDTO.GameIds, prices);
                }
                catch(Exception ex) 
                {
                    
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderPurchaseDto>>> Purchases()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            List<OrderPurchaseDto> purchase = new List<OrderPurchaseDto>();

            if(userId !=  null)
            {
                purchase = await _orderServices.GetOrderPurchasesAsync(userId);
            }
            

            return View(purchase);
        }
    }
}
