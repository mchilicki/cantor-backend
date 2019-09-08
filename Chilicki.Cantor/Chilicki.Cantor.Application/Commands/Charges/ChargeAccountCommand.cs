using Chilicki.Cantor.Application.DTOs;
using MediatR;

namespace Chilicki.Cantor.Application.Commands.Charges
{
    public class ChargeAccountCommand : IRequest<UserDto>
    {
        public decimal Amount { get; set; }
    }
}
