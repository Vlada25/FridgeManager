using AutoMapper;
using FridgeManager.Domain.DTO.Product;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public ProductsController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _repository.ProductRepository.GetAll(trackChanges: false);

            return Ok(products);
        }


        [HttpGet("{id}", Name = "ProductById")]
        public IActionResult Get(Guid id)
        {
            var product = _repository.ProductRepository.GetById(id, trackChanges: false);

            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in datebase");
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForCreationDto object sent from client is null.");
            }

            var productEntity = _mapper.Map<Product>(product);

            _repository.ProductRepository.Create(productEntity);
            _repository.Save();

            return CreatedAtRoute("ProductById", new { id = productEntity.Id }, productEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForUpdateDto object sent from client is null.");
                return BadRequest("ProductForUpdateDto obgect is null");
            }

            var productEntity = _repository.ProductRepository.GetById(product.Id, trackChanges: true);

            if (productEntity == null)
            {
                _logger.LogInfo($"Product with id: {product.Id} doesn't exist in datebase");
                return NotFound();
            }

            _mapper.Map(product, productEntity);
            _repository.Save();

            return Ok("Product was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = _repository.ProductRepository.GetById(id, trackChanges: false);

            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.ProductRepository.Delete(product);
            _repository.Save();

            return Ok("Product was deleted");
        }

        #endregion
    }
}
