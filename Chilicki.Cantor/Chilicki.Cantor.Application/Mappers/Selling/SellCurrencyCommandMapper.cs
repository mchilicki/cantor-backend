using Chilicki.Cantor.Application.Commands.Selling;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Selling.Base;
using Chilicki.Cantor.Domain.Commands.Selling;
using Chilicki.Cantor.Domain.Services.Calculations.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers.Selling
{
    public class SellCurrencyCommandMapper : ISellCurrencyCommandMapper
    {
        readonly ICurrentUserService currentUserService;
        readonly ICantorWalletRepository cantorWalletRepository;
        readonly ICantorCostsCalculator cantorCostsCalculator;
        readonly ICurrencyRepository currencyRepository;

        public SellCurrencyCommandMapper(
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

        public async Task<SellCurrencyCommand> Map(SellCurrencyCommandDto source)
        {
            var currency = await currencyRepository.FindAsync(source.CurrencyId);
            var user = await currentUserService.GetCurrentUserAsync();
            var cantorWallet = cantorWalletRepository.GetCantorWallet();
            var cantorCurrency = cantorWallet.CantorCurrencies
                .FindByCurrency(source.CurrencyId);
            var userMoneyEarns = cantorCostsCalculator.CountUserEarnsInPln(currency, source.Amount);
            var userBoughtCurrency = user.Currencies.FindByCurrency(currency);
            return new SellCurrencyCommand()
            {
                Currency = currency,
                Amount = source.Amount,
                User = user,
                CantorWallet = cantorWallet,
                CantorCurrency = cantorCurrency,
                UserMoneyEarns = userMoneyEarns,
                UserCurrency = userBoughtCurrency,
            };
        }
    }
}
