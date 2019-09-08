using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Calculations.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers
{
    public class BuyCurrencyCommandMapper : IBuyCurrencyCommandMapper
    {
        readonly ICurrentUserService currentUserService;
        readonly ICantorWalletRepository cantorWalletRepository;
        readonly ICantorCostsCalculator cantorCostsCalculator;
        readonly ICurrencyRepository currencyRepository;

        public BuyCurrencyCommandMapper(
            ICurrentUserService currentUserService,
            ICantorWalletRepository cantorWalletRepository,
            ICantorCostsCalculator cantorCostsCalculator,
            ICurrencyRepository currencyRepository)
        {
            this.currentUserService = currentUserService;
            this.cantorWalletRepository = cantorWalletRepository;
            this.cantorCostsCalculator = cantorCostsCalculator;
            this.currencyRepository = currencyRepository;
        }

        public async Task<BuyCurrencyCommand> Map(BuyCurrencyCommandDto source)
        {
            var currency = await currencyRepository.FindAsync(source.CurrencyId);
            var user = await currentUserService.GetCurrentUserAsync();
            var cantorCurrency = cantorWalletRepository.GetCantorWallet().CantorCurrencies
                .FindByCurrency(source.CurrencyId);
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