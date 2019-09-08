using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base
{
    public interface ICantorWalletRepository : IBaseRepository<CantorWallet>
    {
        Task<CantorWallet> GetCantorWalletAsync();
        CantorWallet GetCantorWallet();
    }
}
