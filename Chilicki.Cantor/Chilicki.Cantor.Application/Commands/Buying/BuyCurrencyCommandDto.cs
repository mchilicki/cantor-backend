using Chilicki.Cantor.Application.DTOs;
using MediatR;
using System;

namespace Chilicki.Cantor.Application.Commands.Buying
{
    public class BuyCurrencyCommandDto : IRequest<UserDto>
    {
        public Guid CurrencyId { get; set; }
        public int Amount { get; set; }
    }
}
