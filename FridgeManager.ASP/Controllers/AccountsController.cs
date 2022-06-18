using FridgeManager.ASP.Services;
using FridgeManager.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class AccountsController : Controller
    {
        private readonly string _host;
        private readonly string _tokenKey;

        public AccountsController(Constants constants)
        {
            _host = constants.Host + "Accounts/";
            _tokenKey = constants.TokenKey;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roles = new string[] {"Admin", "Manager" };

            return View(new RegisterUser()
            {
                Roles = roles.ToList()
            });
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
                Response.Cookies.Append(_tokenKey, token, new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(30)
                });

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            ViewData["Message"] = "Login or password is not correct!";
            return View();
        }

        // TODO: Dropdown, multiselect
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
