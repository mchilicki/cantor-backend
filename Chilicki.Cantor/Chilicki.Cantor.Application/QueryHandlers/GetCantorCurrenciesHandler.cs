using AutoMapper;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.QueryHandlers
{
    public class GetCantorCurrenciesHandler : IRequestHandler<GetCantorCurrenciesQuery, IEnumerable<CantorCurrencyDto>>
    {
        readonly ICurrencyRepository _currencyRepository;
        readonly IMapper _mapper;

        public GetCantorCurrenciesHandler(
            ICurrencyRepository currencyRepository,
            IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CantorCurrencyDto>> Handle(
            GetCantorCurrenciesQuery query, CancellationToken cancellationToken)
        {
            var currencies = await _currencyRepository.GetAllAsync();
            var currencyDtos = _mapper.Map<IEnumerable<CantorCurrencyDto>>(currencies);
            return currencyDtos;
        }
    }
}
