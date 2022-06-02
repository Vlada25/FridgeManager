using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class FridgeModelsController : Controller
    {
        private readonly string _host = @"https://localhost:5001/api/FridgeModel/";

        #region CRUD

        [HttpGet]
        [HttpGet("~/[controller]/")]
        public async Task<IActionResult> GetAll()
        {
            using HttpClient http = new();
            var result = await http.GetAsync(_host);

            var models = JsonConvert.DeserializeObject<List<FridgeModelDto>>(result.Content.ReadAsStringAsync().Result);

            return View(models);
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

            var model = JsonConvert.DeserializeObject<FridgeModelDto>(await result.Content.ReadAsStringAsync());

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FridgeModelForCreationDto model)
        {
            using HttpClient httpClient = new();
            await httpClient.PostAsJsonAsync(_host, model);

            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FridgeModelForUpdateDto model)
        {
            using HttpClient httpClient = new();
            await httpClient.PutAsJsonAsync($"{_host}", model);

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

        [HttpGet]
        public IActionResult GetFridgesByModel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetFridgesByModel(Guid modelId)
        {
            using HttpClient httpClient = new();
            var result = await httpClient.GetAsync($"{_host}{modelId}/Fridge");

            var fridges = JsonConvert.DeserializeObject<List<FridgeDto>>(result.Content.ReadAsStringAsync().Result);

            return View(fridges);
        }
    }
}
