using System.Threading.Tasks;
using Chilicki.Cantor.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.Cantor.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        readonly IMediator mediator;

        public CurrenciesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("cantor")]
        public async Task<IActionResult> GetCantorCurrencies([FromQuery]GetCantorCurrenciesQuery command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserCurrencies([FromQuery]GetUserCurrenciesQuery command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}