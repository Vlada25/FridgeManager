using AutoMapper;
using FridgeManager.Domain.Models.Authorization;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public AccountsController(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginUser loginUser)
        {
            if (loginUser == null)
            {
                _logger.LogError("LoginUser object sent from client is null.");
            }

            var user = _repository.UserRepository.GetAll(false)
                .FirstOrDefault(u => u.Login == loginUser.Login && u.Password == loginUser.Password);

            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes("MY_SECRET_KEY");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, loginUser.Login)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized("Try to sign in again!");
            }
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterUser registerUser)
        {
            if (registerUser == null)
            {
                _logger.LogError("RegisterUser object sent from client is null.");
            }

            var user = _mapper.Map<User>(registerUser);

            _repository.UserRepository.Create(user);
            _repository.Save();

            return Ok(user);
        }
    }
}
