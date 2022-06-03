using FridgeManager.Domain.Models.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class AccountsController : Controller
    {
        private readonly string _host = @"https://localhost:5001/api/Accounts/";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using HttpClient httpClient = new();
            var result = await httpClient.PostAsJsonAsync(_host + "Login/", loginUser);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            ViewData["Message"] = "Login or password is not correct!";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using HttpClient httpClient = new();
            var result = await httpClient.PostAsJsonAsync(_host + "Register/", registerUser);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToRoute(new { controller = "Accounts", action = "Login" });
            }

            ViewData["Message"] = "Something went wrong!";
            return View();
        }
    }
}
