using Application.DTO;
using Application.Services;
using Infrastructure.User;
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
        private readonly OrderServices _orderServices;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        public MyOfficeController(OrderServices orderServices, 
            ILogger<MyOfficeController> logger, 
            UserManager<UserModel> userManager, 
            SignInManager<UserModel> signInManager)
        {
            _orderServices = orderServices;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Card()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyGames(OrderDTO orderDTO, string name, string price)
        {
            // Get the user ID, for example, through ASP.NET Identity
            var user = await _userManager.FindByNameAsync(name);

            var userId = user.Id;
            decimal prices;
            CultureInfo culture = CultureInfo.InvariantCulture;
            if (Decimal.TryParse(price, NumberStyles.Any, culture, out prices))
            {
                try
                {
                    _orderServices.CreateOrder(userId, orderDTO.GameIds, prices);
                }
                catch(Exception ex) 
                {
                    
                }
            }

            //  post-purchase processing code ...

            return RedirectToAction("Index", "Home");
        }
    }
}
