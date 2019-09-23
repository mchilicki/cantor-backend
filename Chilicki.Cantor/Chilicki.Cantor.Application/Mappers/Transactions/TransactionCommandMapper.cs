using Chilicki.Cantor.Application.Commands.Transactions;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Transactions.Base;
using Chilicki.Cantor.Domain.Commands.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers.Transactions
{
    public class TransactionCommandMapper : ITransactionCommandMapper
    {
        readonly ICurrentUserService currentUserService;
        readonly ICantorWalletRepository cantorWalletRepository;
        readonly ICurrencyRepository currencyRepository;

        public TransactionCommandMapper(
            ICurrentUserService currentUserService,
            ICantorWalletRepository cantorWalletRepository,
            ICurrencyRepository currencyRepository)
        {
            this.currentUserService = currentUserService;
            this.cantorWalletRepository = cantorWalletRepository;
            this.currencyRepository = currencyRepository;
        }

        public async Task<T> Map<T>(TransactionCommandDto source) where T: TransactionCommand, new()
        {
            var currency = await currencyRepository.FindAsync(source.CurrencyId);
            var user = await currentUserService.GetCurrentUserAsync();
            var cantorWallet = cantorWalletRepository.GetCantorWallet();
            var cantorCurrency = cantorWallet.CantorCurrencies
                .FindByCurrency(source.CurrencyId);
            var userBoughtCurrency = user.Currencies.FindByCurrency(currency);
            return new T()
            {
                Currency = currency,
                Amount = source.Amount,
                User = user,
                CantorWallet = cantorWallet,
                CantorCurrency = cantorCurrency,
                UserCurrency = userBoughtCurrency,
            };
        }
    }
}
