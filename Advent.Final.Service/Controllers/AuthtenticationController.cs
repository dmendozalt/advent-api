using Advent.Final.Contracts.Repository;
using Advent.Final.Core.V1;
using Advent.Final.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advent.Final.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthtenticationController : ControllerBase
    {
        private readonly AuthtenticationCore _core;

        public AuthtenticationController(ILogger<User> userLogger,IMapper mapper,IUserRepository userRepository,IConfiguration configuration)
        {
            _core = new(userRepository,userLogger,mapper,configuration);
        }
        // POST api/<AuthtenticationController>
        [HttpPost]
        public string Login(string username, string password)
        {
            return password;
        }

    }
}
