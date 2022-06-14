﻿using AutoMapper;
using FridgeManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    // TODO: Implement user controller
    public class UsersController : ControllerBase
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

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

            return Ok(users);
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
                return Ok(user);
            }
        }
    }
}
