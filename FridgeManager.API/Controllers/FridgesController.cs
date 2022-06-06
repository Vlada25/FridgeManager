using AutoMapper;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeProduct;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FridgesController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public FridgesController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public IActionResult GetAll()
        {
            var fridges = _repository.FridgeRepository.GetAll(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }


        [HttpGet("{id}", Name = "FridgeById")]
        public IActionResult Get(Guid id)
        {
            var fridge = _repository.FridgeRepository.GetById(id, trackChanges: false);

            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in datebase");
                return NotFound();
            }
            else
            {
                var fridgeDto = _mapper.Map<FridgeDto>(fridge);
                return Ok(fridgeDto);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FridgeForCreationDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
            }

            var fridgeEntity = _mapper.Map<Fridge>(fridge);

            _repository.FridgeRepository.Create(fridgeEntity);
            _repository.Save();

            var fridgeToReturn = _mapper.Map<FridgeDto>(fridgeEntity);

            return CreatedAtRoute("FridgeById", new { id = fridgeToReturn.Id }, fridgeToReturn);
        }

        [HttpPut]
        public IActionResult Update([FromBody] FridgeForUpdateDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForUpdateDto object sent from client is null.");
                return BadRequest("FridgeForUpdateDto obgect is null");
            }

            var fridgeEntity = _repository.FridgeRepository.GetById(fridge.Id, trackChanges: true);

            if (fridgeEntity == null)
            {
                _logger.LogInfo($"Fridge with id: {fridge.Id} doesn't exist in datebase");
                return NotFound();
            }

            _mapper.Map(fridge, fridgeEntity);
            _repository.Save();

            return Ok("Fridge was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var fridge = _repository.FridgeRepository.GetById(id, trackChanges: false);

            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.FridgeRepository.Delete(fridge);
            _repository.Save();

            return Ok("Fridge was deleted");
        }

        #endregion

        #region Actions with products

        /// <summary>
        /// Getting products by fridge id
        /// (main task and also query set 2(1)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetProductsInFridge(Guid id)
        {
            var fridge = _repository.FridgeRepository.GetById(id, trackChanges: false);

            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var fridgeProducts = _repository.FridgeProductRepository.GetProductsInFridge(id, trackChanges: false);
            var fridgeProductsToReturn = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProducts);

            return Ok(fridgeProductsToReturn);
        }

        /// <summary>
        /// Getting all products in all fridges
        /// (main task and also query set 2(2)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllProductsInAllFridges()
        {
            var fridgeProducts = _repository.FridgeProductRepository.GetAll(trackChanges: false);
            var fridgeProductsToReturn = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProducts);

            return Ok(fridgeProductsToReturn);
        }

        [HttpPost]
        public IActionResult PutProductInFridge([FromBody] FridgeProductForCreationDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError("FridgeProductForCreationDto object sent from client is null.");
            }

            var fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProduct);

            try
            {
                _repository.FridgeProductRepository.Create(fridgeProductEntity);
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Product was put in fridge");
        }

        [HttpPut]
        public IActionResult UpdateProductInFridge([FromBody] FridgeProductForUpdateDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError("FridgeProductForUpdateDto object sent from client is null.");
                return BadRequest("FridgeProductForUpdateDto obgect is null");
            }

            var fridgeProductEntity = _repository.FridgeProductRepository.GetById(fridgeProduct.Id, trackChanges: true);

            if (fridgeProductEntity == null)
            {
                _logger.LogInfo($"FridgeProduct with id: {fridgeProduct.Id} doesn't exist in datebase");
                return NotFound();
            }

            _mapper.Map(fridgeProduct, fridgeProductEntity);
            _repository.Save();

            return Ok("Product in fridge was updated");
        }

        [HttpDelete("{fridgeProductId}")]
        public IActionResult DeleteProductFromFridge(Guid fridgeProductId)
        {
            var fridgeProduct = _repository.FridgeProductRepository.GetById(fridgeProductId, trackChanges: false);

            if (fridgeProduct == null)
            {
                _logger.LogInfo($"Such product in fridge doesn't exist in the database.");
                return NotFound();
            }

            _repository.FridgeProductRepository.Delete(fridgeProduct);
            _repository.Save();

            return Ok("Product was removed from the fridge");
        }

        #endregion

        #region Special queries

        /// <summary>
        /// Change products in fridge with quantity = 0 on default quantity
        /// (minimal requirements #6)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ChangeNullQuantity()
        {
            _repository.FridgeProductRepository.ChangeNullQuantity();

            var fridgeProducts = _repository.FridgeProductRepository.GetAll(trackChanges: false);
            var fridgeProductsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProducts);

            return Ok(fridgeProductsDto);
        }

        /// <summary>
        /// Searching fridge by letters or words, which fridge name contains
        /// (additional task #1)
        /// </summary>
        /// <param name="substring"></param>
        /// <returns></returns>
        [HttpGet("{substring}")]
        public IActionResult SearchFridgesBySubstring(string substring)
        {
            var fridges = _repository.FridgeRepository.SearchFridgesBySubstring(substring, trackChanges: false).ToList();
                
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }

        /// <summary>
        /// Getting year of model of the most specious fridge (by total products quantity)
        /// (additional task #3)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetYearOfTheMostSpaciousFridge()
        {
            int year = _repository.FridgeRepository.GetYearOfTheMostSpaciousFridge();

            return Ok($"Year of the most spacious fridge: {year}");
        }

        /// <summary>
        /// Getting string which contains count of kinds products and Id of fridge
        /// which contains max count of kinds of products
        /// (additional task #4, but with some changes, 
        /// you can get products in fridge by id in the other query)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFridgeWhichContainsTheMostKindsOfProducts()
        {
            string outStr = _repository.FridgeRepository.GetFridgeWhichContainsTheMostKindsOfProducts();

            return Ok(outStr);
        }
        #endregion
    }
}
