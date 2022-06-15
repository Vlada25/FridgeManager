using FridgeManager.Domain.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class AccountsController : Controller
    {
        private readonly string _host;

        public AccountsController(string host)
        {
            _host = host + "Accounts/";
        }

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
                var token = result.Content.ReadAsStringAsync().Result;
                Response.Cookies.Append("X-Access-Token", token, new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(30)
                });

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            ViewData["Message"] = "Login or password is not correct!";
            return View();
        }

        // TODO: Add roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            registerUser.Roles = new List<string>();

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
