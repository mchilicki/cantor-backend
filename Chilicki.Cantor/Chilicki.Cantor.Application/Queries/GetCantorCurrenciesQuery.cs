using Chilicki.Cantor.Application.DTOs.Currencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Queries
{
    public class GetCantorCurrenciesQuery : IRequest<IEnumerable<CantorCurrencyDto>>
    {
    }
}
