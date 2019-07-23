using AutoMapper;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.QueryHandlers
{
    public class GetUserCurrenciesHandler : IRequestHandler<GetUserCurrenciesQuery, IEnumerable<UserCurrencyDto>>
    {
        readonly IWalletCurrencyRepository _walletCurrencyRepository;
        readonly IMapper _mapper;

        public GetUserCurrenciesHandler(
            IWalletCurrencyRepository walletCurrencyRepository,
            IMapper mapper)
        {
            _walletCurrencyRepository = walletCurrencyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCurrencyDto>> Handle(GetUserCurrenciesQuery request, CancellationToken cancellationToken)
        {
            // add getting per user
            var currencies = await _walletCurrencyRepository.GetAllAsync();
            var currencyDtos = _mapper.Map<IEnumerable<UserCurrencyDto>>(currencies);
            return currencyDtos;
        }
    }
}
