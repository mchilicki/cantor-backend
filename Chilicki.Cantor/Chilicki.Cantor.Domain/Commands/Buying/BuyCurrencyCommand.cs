using Chilicki.Cantor.Domain.Commands.Base;
using Chilicki.Cantor.Domain.Entities;

namespace Chilicki.Cantor.Domain.Commands.Buying
{
    public class BuyCurrencyCommand : TransactionCommand
    {
        public decimal UserMoneyCosts { get; set; }
    }
}
