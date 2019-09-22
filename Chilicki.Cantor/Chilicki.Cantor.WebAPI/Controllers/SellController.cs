using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chilicki.Cantor.Application.Commands.Selling;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.Cantor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        readonly IMediator mediator;

        public SellController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("currency")]
        public async Task<IActionResult> SellCurrency([FromBody]SellCurrencyCommandDto command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}