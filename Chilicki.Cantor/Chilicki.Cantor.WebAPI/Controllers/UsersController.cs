using System.Threading.Tasks;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.Commands.Charges;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.Cantor.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateUserCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("charge")]
        public async Task<IActionResult> ChargeAccount([FromBody]ChargeAccountCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}