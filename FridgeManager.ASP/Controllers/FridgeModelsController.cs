using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeManager.ASP.Services;
using FridgeManager.Domain.Models;
using FridgeManager.DTO.Fridge;
using FridgeManager.DTO.FridgeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.ASP.Controllers
{
    [Route("[controller]/[action]/")]
    [Authorize]
    public class FridgeModelsController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public FridgeModelsController(Constants constants,
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(constants.Host + "FridgeModels/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies[constants.TokenKey];

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
