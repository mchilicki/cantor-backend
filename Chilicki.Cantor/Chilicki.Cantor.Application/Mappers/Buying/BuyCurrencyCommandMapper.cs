using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Application.Mappers.Transactions.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Services.Calculations.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers.Buying
{
    public class BuyCurrencyCommandMapper : IBuyCurrencyCommandMapper
    {
        readonly ICantorCostsCalculator cantorCostsCalculator;
        readonly ITransactionCommandMapper transactionCommandMapper;

        public BuyCurrencyCommandMapper(
            ICantorCostsCalculator cantorCostsCalculator,
            ITransactionCommandMapper transactionCommandMapper)
        {
            this.cantorCostsCalculator = cantorCostsCalculator;
            this.transactionCommandMapper = transactionCommandMapper;
        }

        public async Task<BuyCurrencyCommand> Map(BuyCurrencyCommandDto source)
        {
            var command = await transactionCommandMapper.Map<BuyCurrencyCommand>(source);
            command.UserMoneyCosts = cantorCostsCalculator.CountUserCostsInPln(command.Currency, source.Amount);
            return command;
        }
    }
}