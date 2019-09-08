using System.Threading.Tasks;

namespace Chilicki.Cantor.Infrastructure.UnitsOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Dispose();
    }
}
