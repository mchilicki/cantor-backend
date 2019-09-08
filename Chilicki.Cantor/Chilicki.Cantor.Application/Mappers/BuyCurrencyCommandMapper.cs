using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Calculations.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;

namespace Chilicki.Cantor.Application.Mappers
{
    public class BuyCurrencyCommandMapper : IBuyCurrencyCommandMapper
    {
        readonly ICurrentUserService currentUserService;
        readonly ICantorWalletRepository cantorWalletRepository;
        readonly ICantorCostsCalculator cantorCostsCalculator;
        readonly IMapper mapper;

        public BuyCurrencyCommandMapper(
            ICurrentUserService currentUserService,
            ICantorWalletRepository cantorWalletRepository,
            ICantorCostsCalculator cantorCostsCalculator,
            IMapper mapper)
        {
            this.currentUserService = currentUserService;
            this.cantorWalletRepository = cantorWalletRepository;
            this.cantorCostsCalculator = cantorCostsCalculator;
            this.mapper = mapper;
        }

        public BuyCurrencyCommand Map(BuyCurrencyCommandDto source)
        {
            var currency = mapper.Map<Currency>(source.Currency);
            var user = currentUserService.GetCurrentUser();
            var cantorCurrency = cantorWalletRepository.GetCantorWallet().CantorCurrencies
                .FindByCurrency(source.Currency.Id);
            var userMoneyCosts = cantorCostsCalculator.CountUserCostsInPln(currency, source.Amount);
            var userBoughtCurrency = user.Currencies.FindByCurrency(currency);
            return new BuyCurrencyCommand()
            {
                Currency = currency,
                Amount = source.Amount,
                User = user,
                CantorCurrency = cantorCurrency,
                UserMoneyCosts = userMoneyCosts,
                UserBoughtCurrency = userBoughtCurrency,
            };
        }
    }
}