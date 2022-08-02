using Advent.Final.Contracts.Repository;
using Advent.Final.Core.V1;
using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advent.Final.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserCore _core;

        public UsersController(ILogger<User> logger, IMapper mapper, IUserRepository context)
        {
            _core = new(context, logger, mapper);
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<List<User>>> Get()
        {
            var response=await _core.GetAll();
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateDto user)
        {
            var response=await _core.CreateUser(user);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<ActionResult<User>> UpdatePassword(int idUser, string password)
        {
            var response=await _core.UpdatePassword(idUser,password);
            return StatusCode((int)response.StatusHttp, response);
        }
    }
}
