using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base
{
    public interface ICantorWalletRepository : IBaseRepository<CantorWallet>
    {
        Task<CantorWallet> GetCantor();
    }
}
