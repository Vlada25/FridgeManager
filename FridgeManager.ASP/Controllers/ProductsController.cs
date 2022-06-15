using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeManager.Domain.DTO.Product;
using FridgeManager.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductsController(string host,
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(host + "Products/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
                _flurlClient.WithOAuthBearerToken(token);
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flurlClient.Request("GetAll").GetJsonAsync<List<Product>>();

            return View(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _flurlClient.Request($"Get/{id}").GetJsonAsync<Product>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Product not found!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductForCreationDto product)
        {
            await _flurlClient.Request("Create/").PostJsonAsync(product);

            ViewData["Message"] = $"Product {product.Name} was created";
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductForUpdateDto product)
        {
            await _flurlClient.Request("Update/").PutJsonAsync(product);

            ViewData["Message"] = $"Product {product.Name} was updated";
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _flurlClient.Request($"Delete/{id}").DeleteAsync();

            ViewData["Message"] = $"Product with id = {id} was deleted";
            return View();
        }

        #endregion
    }
}
