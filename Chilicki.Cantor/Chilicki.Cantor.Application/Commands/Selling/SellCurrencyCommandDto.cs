using Chilicki.Cantor.Application.Commands.Transactions;
using Chilicki.Cantor.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.Commands.Selling
{
    public class SellCurrencyCommandDto : TransactionCommandDto, IRequest<UserDto>
    {
        
    }
}
