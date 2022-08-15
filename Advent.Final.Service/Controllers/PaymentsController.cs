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
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentCore _core;
        public PaymentsController(IPaymentMethodRepository context,ILogger<PaymentMethod> logger, IMapper mapper)
        {
            _core=new(context, mapper, logger);
        }


        // GET api/<PaymentsController>/5
        [HttpGet("/methods/{idUser}")]
        public async Task<ActionResult<List<PaymentMethod>>> GetPaymentMethods(int idUser)
        {
            var response = await _core.GetAllMethods(idUser);
            return StatusCode((int)response.StatusHttp,response);
        }
    }
}
