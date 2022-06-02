using FridgeManager.Domain.DTO.Product;
using FridgeManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class ProductsController : Controller
    {
        private readonly string _host = @"https://localhost:5001/api/Product/";

        [HttpGet]
        [HttpGet("~/[controller]/")]
        public async Task<IActionResult> GetAll()
        {
            using HttpClient http = new();
            var result = await http.GetAsync(_host);

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
            var result = await httpClient.GetAsync($"{_host}{id}");

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
            await httpClient.PostAsJsonAsync(_host, product);

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
            await httpClient.PutAsJsonAsync($"{_host}", product);

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
            await httpClient.DeleteAsync($"{_host}{id}");

            return View();
        }
    }
}
