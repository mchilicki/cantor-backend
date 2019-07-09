using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.UnitsOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
