using Chilicki.Cantor.Application.Commands.Transactions;
using Chilicki.Cantor.Domain.Commands.Base;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Mappers.Transactions.Base
{
    public interface ITransactionCommandMapper
    {
        Task<T> Map<T>(TransactionCommandDto source) where T : TransactionCommand, new();
    }
}