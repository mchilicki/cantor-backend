using AutoMapper;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.QueryHandlers
{
    public class GetCantorCurrenciesHandler : IRequestHandler<GetCantorCurrenciesQuery, IEnumerable<CantorCurrencyDto>>
    {
        readonly ICurrencyRepository currencyRepository;
        readonly IMapper mapper;

        public GetCantorCurrenciesHandler(
            ICurrencyRepository currencyRepository,
            IMapper mapper)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CantorCurrencyDto>> Handle(
            GetCantorCurrenciesQuery query, CancellationToken cancellationToken)
        {
            var currencies = await currencyRepository.GetAllAsync();
            var currencyDtos = mapper.Map<IEnumerable<CantorCurrencyDto>>(currencies);
            return currencyDtos;
        }
    }
}
