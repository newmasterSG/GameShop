using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class ChatsViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (!User.IsInRole("Admin"))
            {
                return View("ChatUser");
            }

            return View("ChatAdmin");
        }
    }
}
