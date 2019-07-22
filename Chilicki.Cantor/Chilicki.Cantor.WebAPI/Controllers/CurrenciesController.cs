using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chilicki.Cantor.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.Cantor.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    public class CurrenciesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CurrenciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cantor")]
        public async Task<IActionResult> GetCantorCurrencies([FromQuery]GetCantorCurrenciesQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}