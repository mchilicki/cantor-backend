using Chilicki.Cantor.Application.DTOs.Currencies;
using MediatR;
using System.Collections.Generic;

namespace Chilicki.Cantor.Application.Queries
{
    public class GetCantorCurrenciesQuery : IRequest<IEnumerable<CantorCurrencyDto>>
    {
    }
}
