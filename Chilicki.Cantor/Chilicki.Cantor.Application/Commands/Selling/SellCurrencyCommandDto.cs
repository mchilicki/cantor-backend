using Chilicki.Cantor.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.Commands.Selling
{
    public class SellCurrencyCommandDto : IRequest<UserDto>
    {
        public Guid CurrencyId { get; set; }
        public int Amount { get; set; }
    }
}
