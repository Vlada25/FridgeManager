using FridgeManager.Domain.DTO.Fridge;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class FridgesController : Controller
    {
        private readonly string _host = @"https://localhost:5001/api/Fridge/";

        #region CRUD

        [HttpGet]
        [HttpGet("~/[controller]/")]
        public async Task<IActionResult> GetAll()
        {
            using HttpClient httpClient = new();
            var result = await httpClient.GetAsync(_host);

            var fridges = JsonConvert.DeserializeObject<List<FridgeDto>>(result.Content.ReadAsStringAsync().Result);

            return View(fridges);
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

            var fridge = JsonConvert.DeserializeObject<FridgeDto>(await result.Content.ReadAsStringAsync());

            return View(fridge);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FridgeForCreationDto fridge)
        {
            using HttpClient httpClient = new();
            await httpClient.PostAsJsonAsync(_host, fridge);

            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FridgeForUpdateDto fridge)
        {
            using HttpClient httpClient = new();
            await httpClient.PutAsJsonAsync($"{_host}", fridge);

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

        #endregion
    }
}
