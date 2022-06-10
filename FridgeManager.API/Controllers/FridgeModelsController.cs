using AutoMapper;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeModel;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FridgeModelsController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public FridgeModelsController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        #region CRUD

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var models = _repository.FridgeModelRepository.GetAll(trackChanges: false);

            return Ok(models);
        }

        [HttpGet("{id}", Name = "ModelById")]
        public IActionResult Get(Guid id)
        {
            var model = _repository.FridgeModelRepository.GetById(id, trackChanges: false);

            if (model == null)
            {
                _logger.LogInfo($"Fridge model with id: {id} doesn't exist in datebase");
                return NotFound();
            }
            else
            {
                return Ok(model);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FridgeModelForCreationDto model)
        {
            if (model == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
            }

            var modelEntity = _mapper.Map<FridgeModel>(model);

            _repository.FridgeModelRepository.Create(modelEntity);
            _repository.Save();

            return CreatedAtRoute("ModelById", new { id = modelEntity.Id }, modelEntity);
        }

        [HttpPut]
        public IActionResult Update([FromBody] FridgeModelForUpdateDto model)
        {
            if (model == null)
            {
                _logger.LogError("FridgeModelForUpdateDto object sent from client is null.");
                return BadRequest("FridgeModelForUpdateDto obgect is null");
            }

            var modelEntity = _repository.FridgeModelRepository.GetById(model.Id, trackChanges: true);

            if (modelEntity == null)
            {
                _logger.LogInfo($"FridgeModel with id: {model.Id} doesn't exist in datebase");
                return NotFound();
            }

            _mapper.Map(model, modelEntity);
            _repository.Save();

            return Ok("Fridge model was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var model = _repository.FridgeModelRepository.GetById(id, trackChanges: false);

            if (model == null)
            {
                _logger.LogInfo($"Model with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.FridgeModelRepository.Delete(model);
            _repository.Save();

            return Ok("Fridge model was deleted");
        }

        #endregion

        [HttpGet("{modelId}/fridges")]
        public IActionResult GetFridgesByModel(Guid modelId)
        {
            var model = _repository.FridgeModelRepository.GetById(modelId, trackChanges: false);

            if (model == null)
            {
                _logger.LogInfo($"Fridge model with id: {modelId} doesn't exist in datebase");
                return NotFound();
            }

            var fridgesFromDb = _repository.FridgeRepository.GetFridgesByModel(modelId, trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridgesFromDb);

            return Ok(fridgesDto);
        }
    }
}
