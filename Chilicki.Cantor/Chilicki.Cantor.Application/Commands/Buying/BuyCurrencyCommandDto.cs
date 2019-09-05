using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.DTOs.Currencies;
using MediatR;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.Commands.Buying
{
    public class BuyCurrencyCommandDto : IRequest<UserDto>
    {
        public UserCurrencyDto Currency { get; set; }
        public int Amount { get; set; }
    }
}
