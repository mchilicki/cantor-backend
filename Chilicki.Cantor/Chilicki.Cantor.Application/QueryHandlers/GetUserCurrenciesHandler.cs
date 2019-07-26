using AutoMapper;
using Chilicki.Cantor.Application.DTOs.Currencies;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Queries;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Wallets.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.QueryHandlers
{
    public class GetUserCurrenciesHandler : IRequestHandler<GetUserCurrenciesQuery, IEnumerable<UserCurrencyDto>>
    {
        readonly IWalletCurrencyRepository walletCurrencyRepository;
        readonly IMapper mapper;
        readonly ICurrentUserService currentUserService;

        public GetUserCurrenciesHandler(
            IWalletCurrencyRepository walletCurrencyRepository,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            this.walletCurrencyRepository = walletCurrencyRepository;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<UserCurrencyDto>> Handle(GetUserCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var user = await currentUserService.GetCurrentUser();
            var currencyDtos = mapper.Map<IEnumerable<UserCurrencyDto>>(user.BoughtCurrencies);
            return currencyDtos;
        }
    }
}
