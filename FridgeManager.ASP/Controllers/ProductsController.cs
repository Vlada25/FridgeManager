using FridgeManager.Domain.DTO.Product;
using FridgeManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class ProductsController : Controller
    {
        private readonly string _host;

        public ProductsController(string host)
        {
            _host = host + "Products/";
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using HttpClient http = new();
            var result = await http.GetAsync(_host + "GetAll");

            var products = JsonConvert.DeserializeObject<List<Product>>(result.Content.ReadAsStringAsync().Result);

            return View(products);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(Guid id)
        {
            using HttpClient httpClient = new();
            var result = await httpClient.GetAsync($"{_host}Get/{id}");

            var product = JsonConvert.DeserializeObject<Product>(await result.Content.ReadAsStringAsync());

            return View(product);
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
            using HttpClient httpClient = new();
            await httpClient.PostAsJsonAsync($"{_host}Create/", product);

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
            using HttpClient httpClient = new();
            await httpClient.PutAsJsonAsync($"{_host}Update/", product);

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
            using HttpClient httpClient = new();
            await httpClient.DeleteAsync($"{_host}Delete/{id}");

            ViewData["Message"] = $"Product with id = {id} was deleted";
            return View();
        }

        #endregion
    }
}
