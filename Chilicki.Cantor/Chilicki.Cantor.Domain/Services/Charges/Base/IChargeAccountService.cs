using Chilicki.Cantor.Domain.Entities;

namespace Chilicki.Cantor.Domain.Services.Charges.Base
{
    public interface IChargeAccountService
    {
        User ChargeUserAccount(User user, decimal amount);
    }
}
