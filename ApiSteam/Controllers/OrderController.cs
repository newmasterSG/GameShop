using Application.DTO;
using Application.Services;
using Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ApiSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly OrderServices _orderServices;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        public OrderController(OrderServices orderServices, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _orderServices = orderServices;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("BuyGames")]
        public async Task<IActionResult> BuyGames(OrderDTO orderDTO, string name, string price)
        {
            // Get the user, for example, through ASP.NET Identity
            var user = await _userManager.FindByNameAsync(name);

            decimal prices;
            CultureInfo culture = CultureInfo.InvariantCulture;
            if (Decimal.TryParse(price, NumberStyles.Any, culture, out prices))
            {
                try
                {
                    _orderServices.CreateOrder(user, orderDTO.GameIds, prices);
                }
                catch (Exception ex)
                {

                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
