using Chilicki.Cantor.Application.Commands.Selling;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Selling.Base;
using Chilicki.Cantor.Application.Mappers.Transactions.Base;
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
        readonly ICantorCostsCalculator cantorCostsCalculator;
        readonly ITransactionCommandMapper transactionCommandMapper;

        public SellCurrencyCommandMapper(
            ICantorCostsCalculator cantorCostsCalculator,
            ITransactionCommandMapper transactionCommandMapper)
        {
            this.cantorCostsCalculator = cantorCostsCalculator;
            this.transactionCommandMapper = transactionCommandMapper;
        }

        public async Task<SellCurrencyCommand> Map(SellCurrencyCommandDto source)
        {
            var command = await transactionCommandMapper.Map<SellCurrencyCommand>(source);
            command.UserMoneyEarns = cantorCostsCalculator.CountUserEarnsInPln(command.Currency, source.Amount);
            return command;
        }
    }
}
