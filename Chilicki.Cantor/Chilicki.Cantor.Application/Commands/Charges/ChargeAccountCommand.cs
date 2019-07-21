using Chilicki.Cantor.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Commands.Charges
{
    public class ChargeAccountCommand : IRequest<UserDTO>
    {
        public decimal Ammount { get; set; }
    }
}
