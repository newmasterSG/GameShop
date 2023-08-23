using Microsoft.AspNetCore.Mvc;

namespace ApiSteam.Controllers
{
    [ApiController]
    public class SecretController : Controller
    {
        [Route("/secret")]
        public string Index()
        {
            return "Steam";
        }
    }
}
