using AutoMapper;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.Models;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public FridgeController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFridges()
        {
            var fridges = _repository.FridgeRepository.GetAll(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }


        [HttpGet("{id}", Name = "FridgeById")]
        public IActionResult GetFridge(Guid id)
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
        public IActionResult CreateFridge([FromBody] FridgeForCreationDto fridge)
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
        public IActionResult UpdateFridge([FromBody] FridgeForUpdateDto fridge)
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

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFridge(Guid id)
        {
            var fridge = _repository.FridgeRepository.GetById(id, trackChanges: false);

            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.FridgeRepository.Delete(fridge);
            _repository.Save();

            return NoContent();
        }
    }
}
