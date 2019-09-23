using Chilicki.Cantor.Application.Commands.Transactions;
using Chilicki.Cantor.Application.DTOs;
using MediatR;
using System;

namespace Chilicki.Cantor.Application.Commands.Buying
{
    public class BuyCurrencyCommandDto : TransactionCommandDto, IRequest<UserDto>
    {
    }
}
