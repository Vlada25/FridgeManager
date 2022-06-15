using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeModel;
using FridgeManager.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    [Authorize]
    public class FridgeModelsController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public FridgeModelsController(string host,
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(host + "FridgeModels/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
                _flurlClient.WithOAuthBearerToken(token);
        }

        #region CRUD

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flurlClient.Request("GetAll").GetJsonAsync<List<FridgeModel>>();

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
                var result = await _flurlClient.Request($"Get/{id}").GetJsonAsync<FridgeModel>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Model not found!";
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
        public async Task<IActionResult> Create(FridgeModelForCreationDto model)
        {
            try
            {
                await _flurlClient.Request("Create/").PostJsonAsync(model);

                ViewData["Message"] = $"Model {model.Name} was created";
            }
            catch
            {
                ViewData["Message"] = null;
            }
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
            try
            {
                await _flurlClient.Request("Update/").PutJsonAsync(model);

                ViewData["Message"] = $"Model {model.Name} was updated";
            }
            catch
            {
                ViewData["Message"] = null;
            }
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
            try
            {
                await _flurlClient.Request($"Delete/{id}").DeleteAsync();

                ViewData["Message"] = $"Model with id = {id} was deleted";
            }
            catch
            {
                ViewData["Message"] = "Model not found!";
            }
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
            try
            {
                var result = await _flurlClient.Request($"GetFridgesByModel/{modelId}/Fridges")
                    .GetJsonAsync<List<FridgeDto>>();

                return View(result);
            }
            catch
            {
                ViewData["Message"] = $"Model with id = {modelId} not found";
                return View();
            }
        }
    }
}
