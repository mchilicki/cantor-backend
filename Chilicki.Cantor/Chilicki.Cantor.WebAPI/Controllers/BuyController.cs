using System.Threading.Tasks;
using Chilicki.Cantor.Application.Commands.Buying;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.Cantor.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        readonly IMediator mediator;

        public BuyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("currency")]
        public async Task<IActionResult> BuyCurrency([FromBody]BuyCurrencyCommandDto command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}