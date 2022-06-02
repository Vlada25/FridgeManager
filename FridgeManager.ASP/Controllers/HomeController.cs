using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartPage()
        {
            return View();
        }
    }
}
