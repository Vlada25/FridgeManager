using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeManager.Domain.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public UsersController(string host,
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(host + "Users/");
            _contextAccessor = httpContextAccessor;

            // TODO: Add to appsettings.json
            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
                _flurlClient.WithOAuthBearerToken(token);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flurlClient.Request("GetAll").GetJsonAsync<List<UserDto>>();

            return View(result);
        }

        [HttpGet]
        public IActionResult GetByUsername()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetByUsername(string login)
        {
            try
            {
                var result = await _flurlClient.Request($"Get/{login}").GetJsonAsync<UserDto>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "User not found!";
                return View();
            }
        }
    }
}
