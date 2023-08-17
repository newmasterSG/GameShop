using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class LoginRegisterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("LogoutButton");
            }
            else
            {
                return View("LoginRegisterDropdown");
            }
        }
    }
}
