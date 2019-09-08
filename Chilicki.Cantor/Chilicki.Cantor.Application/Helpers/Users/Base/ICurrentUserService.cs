using Chilicki.Cantor.Domain.Entities;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Helpers.Users.Base
{
    public interface ICurrentUserService
    {
        Task<User> GetCurrentUserAsync();
        User GetCurrentUser();
    }
}
