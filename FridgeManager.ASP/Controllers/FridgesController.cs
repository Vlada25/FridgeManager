using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Administration;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    [Authorize]
    public class FridgesController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public FridgesController(string host, 
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(host + "Fridges/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
                _flurlClient.WithOAuthBearerToken(token);
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flurlClient.Request("GetAll").GetJsonAsync<List<FridgeDto>>();

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
                var result = await _flurlClient.Request($"Get/{id}").GetJsonAsync<FridgeDto>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Fridge not found!";
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
        public async Task<IActionResult> Create(FridgeForCreationDto fridge)
        {
            await _flurlClient.Request("Create/").PostJsonAsync(fridge);

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
            await _flurlClient.Request("Update/").PutJsonAsync(fridge);

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
            await _flurlClient.Request($"Delete/{id}").DeleteAsync();

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
            try
            {
                var result = await _flurlClient.Request($"GetProductsInFridge/{id}").GetJsonAsync<List<FridgeProductDto>>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Fridge not found!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsInAllFridges()
        {
            var result = await _flurlClient.Request("GetAllProductsInAllFridges").GetJsonAsync<List<FridgeProductDto>>();

            return View(result);
        }

        [HttpGet]
        public IActionResult PutProductInFridge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PutProductInFridge(FridgeProductForCreationDto fridgeProduct)
        {
            await _flurlClient.Request("PutProductInFridge/").PostJsonAsync(fridgeProduct);

            ViewData["Message"] = $"Product was put in fridge";
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProductInFridge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductInFridge(FridgeProductForUpdateDto fridgeProduct)
        {
            await _flurlClient.Request("UpdateProductInFridge/").PutJsonAsync(fridgeProduct);

            ViewData["Message"] = $"Product was updated";
            return View();
        }

        [HttpGet]
        public IActionResult DeleteProductFromFridge()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductFromFridge(Guid id)
        {
            await _flurlClient.Request($"DeleteProductFromFridge/{id}").DeleteAsync();

            ViewData["Message"] = $"Product was deleted";
            return View();
        }

        #endregion

        #region Special queries

        [HttpGet]
        public IActionResult ChangeNullQuantity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeNullQuantityAction()
        {
            await _flurlClient.Request($"ChangeNullQuantity/").PostAsync();

            ViewData["Message"] = "Null values ​​of products are replaced";
            return View("ChangeNullQuantity");
        }

        [HttpGet]
        public IActionResult SearchFridgesBySubstring()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchFridgesBySubstring(string substring)
        {
            var result = await _flurlClient.Request($"SearchFridgesBySubstring/{substring}").GetJsonAsync<List<FridgeDto>>();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetYearOfTheMostSpaciousFridge()
        {
            var result = await _flurlClient.Request($"GetYearOfTheMostSpaciousFridge").GetStringAsync();

            ViewData["Message"] = result;
            return View("GetSomeSpecialString");
        }

        [HttpGet]
        public async Task<IActionResult> GetFridgeWhichContainsTheMostKindsOfProducts()
        {
            var result = await _flurlClient.Request($"GetFridgeWhichContainsTheMostKindsOfProducts").GetStringAsync();

            ViewData["Message"] = result;
            return View("GetSomeSpecialString");
        }

        [HttpGet]
        public async Task<IActionResult> GetFridgesAndCountOfProducts()
        {
            var result = await _flurlClient.Request($"GetFridgesAndCountOfProducts")
                .GetJsonAsync<List<FridgeWithCountOfProductsDto>>();

            return View(result);
        }

        #endregion
    }
}
