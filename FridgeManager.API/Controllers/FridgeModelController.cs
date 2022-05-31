using AutoMapper;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeModel;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FridgeModelController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public FridgeModelController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllModels()
        {
            var models = _repository.FridgeModelRepository.GetAll(trackChanges: false);
            var modelsDto = _mapper.Map<IEnumerable<FridgeModelDto>>(models);

            return Ok(modelsDto);
        }


        [HttpGet("{id}", Name = "ModelById")]
        public IActionResult GetModel(Guid id)
        {
            var model = _repository.FridgeModelRepository.GetById(id, trackChanges: false);

            if (model == null)
            {
                _logger.LogInfo($"Fridge model with id: {id} doesn't exist in datebase");
                return NotFound();
            }
            else
            {
                var modelDto = _mapper.Map<FridgeModelDto>(model);
                return Ok(modelDto);
            }
        }

        [HttpGet("{modelId}/Fridge")]
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

        [HttpPost]
        public IActionResult CreateModel([FromBody] FridgeModelForCreationDto model)
        {
            if (model == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
            }

            var modelEntity = _mapper.Map<FridgeModel>(model);

            _repository.FridgeModelRepository.Create(modelEntity);
            _repository.Save();

            var modelToReturn = _mapper.Map<FridgeModelDto>(modelEntity);
            return CreatedAtRoute("ModelById", new { id = modelToReturn.Id }, modelToReturn);
        }

        [HttpPut]
        public IActionResult UpdateModel([FromBody] FridgeModelForUpdateDto model)
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

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModel(Guid id)
        {
            var model = _repository.FridgeModelRepository.GetById(id, trackChanges: false);

            if (model == null)
            {
                _logger.LogInfo($"Model with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.FridgeModelRepository.Delete(model);
            _repository.Save();

            return NoContent();
        }
    }
}
