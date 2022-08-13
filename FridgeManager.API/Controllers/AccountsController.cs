using AutoMapper;
using FridgeManager.Domain.Models;
using FridgeManager.DTO.User;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthenticationManager _authManager;

        public AccountsController(IAuthenticationManager authManager,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerManager loggerManager,
            IMapper mapper)
        {
            _authManager = authManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            if (loginUser == null)
            {
                _logger.LogError("LoginUser object sent from client is null.");
            }

            if (!await _authManager.ValidateUser(loginUser))
            {
                _logger.LogWarn("Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }

            string token = await _authManager.CreateToken();

            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            foreach (var roleName in registerUser.Roles)
            {
                var roleResult = await _roleManager.RoleExistsAsync(roleName);

                if (!roleResult)
                {
                    return BadRequest($"Role {roleName} is not exist");
                }
            }

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, registerUser.Roles);

            return StatusCode(201);
        }
    }
}
