using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Charges.Base;

namespace Chilicki.Cantor.Domain.Services.Charges
{
    public class ChargeAccountService : IChargeAccountService
    {
        public User ChargeUserAccount(User user, decimal amount)
        {
            user.Money += amount;
            return user;
        }
    }
}
