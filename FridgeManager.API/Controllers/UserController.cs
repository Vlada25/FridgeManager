using AutoMapper;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public UserController(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repository.UserRepository.GetAll(trackChanges: false);

            return Ok(users);
        }

        [HttpGet("{login}")]
        public IActionResult GetUser(string login)
        {
            var user = _repository.UserRepository.GetByLogin(login, trackChanges: false);

            if (user == null)
            {
                _logger.LogInfo($"User with login '{login}' doesn't exist in datebase");
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
