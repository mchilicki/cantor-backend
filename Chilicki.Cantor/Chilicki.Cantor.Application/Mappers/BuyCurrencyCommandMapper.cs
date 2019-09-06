using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Calculations.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;

namespace Chilicki.Cantor.Application.Mappers
{
    public class BuyCurrencyCommandMapper : ITypeConverter<BuyCurrencyCommandDto, BuyCurrencyCommand>
    {
        readonly ICurrentUserService currentUserService;
        readonly ICantorWalletRepository cantorWalletRepository;
        readonly ICantorCostsCalculator cantorCostsCalculator;

        public BuyCurrencyCommandMapper(
            ICurrentUserService currentUserService,
            ICantorWalletRepository cantorWalletRepository,
            ICantorCostsCalculator cantorCostsCalculator)
        {
            this.currentUserService = currentUserService;
            this.cantorWalletRepository = cantorWalletRepository;
            this.cantorCostsCalculator = cantorCostsCalculator;
        }

        public BuyCurrencyCommand Convert(
            BuyCurrencyCommandDto source, 
            BuyCurrencyCommand destination, 
            ResolutionContext context)
        {
            var currency = context.Mapper.Map<Currency>(source.Currency);
            var user = currentUserService.GetCurrentUser();
            var cantorCurrency = cantorWalletRepository.GetCantorWallet().CantorCurrencies
                .FindByCurrency(source.Currency.Id);
            var userMoneyCosts = cantorCostsCalculator.CountUserCostsInPln(currency, source.Amount);
            var userBoughtCurrency = user.BoughtCurrencies.FindByCurrency(currency);
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