using AutoMapper;
using FridgeManager.Domain.DTO.User;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _repository.UserRepository.GetAll(trackChanges: false);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{login}")]
        public IActionResult Get(string login)
        {
            var user = _repository.UserRepository.GetByLogin(login, trackChanges: false);

            if (user == null)
            {
                _logger.LogInfo($"User with login '{login}' doesn't exist in datebase");
                return NotFound();
            }
            else
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
        }
    }
}
