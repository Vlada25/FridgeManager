using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Administration;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    public class FridgesController : Controller
    {
        // TODO: Move to appsettings.json
        private readonly string _host = @"https://localhost:5001/api/Fridges/";

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using HttpClient httpClient = new();
            var result = await httpClient.GetAsync(_host + "GetAll");

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
            var result = await httpClient.GetAsync($"{_host}Get/{id}");

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
            await httpClient.PostAsJsonAsync($"{_host}Create/", fridge);

            ViewData["Message"] = $"Fridge {fridge.Name} was created";
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
            await httpClient.PutAsJsonAsync($"{_host}Update/", fridge);

            ViewData["Message"] = $"Fridge {fridge.Name} was updated";
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

            ViewData["Message"] = $"Fridge with id = {id} was deleted";
            return View();
        }

        #endregion

        #region Action with products

        [HttpGet]
        public IActionResult GetProductsInFridge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetProductsInFridge(Guid id)
        {
            using HttpClient httpClient = new();
            var result = await httpClient.GetAsync($"{_host}GetProductsInFridge/{id}");

            var fridgeProducts = JsonConvert.DeserializeObject<List<FridgeProductTotalDto>>(result.Content.ReadAsStringAsync().Result);

            return View(fridgeProducts);
        }

        [HttpGet]
        public IActionResult PutProductInFridge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PutProductInFridge(FridgeProductForCreationDto fridgeProduct)
        {
            using HttpClient httpClient = new();
            await httpClient.PostAsJsonAsync($"{_host}PutProductInFridge/", fridgeProduct);

            ViewData["Message"] = $"Product was put in fridge";
            return View();
        }

        #endregion

        // TODO: Error 405 (ChangeNullQuantity)
        [HttpPost]
        public async Task<IActionResult> ChangeNullQuantity()
        {
            using HttpClient httpClient = new();
            await httpClient.PostAsync($"{_host}/ChangeNullQuantity", null);

            return View();
        }
    }
}
