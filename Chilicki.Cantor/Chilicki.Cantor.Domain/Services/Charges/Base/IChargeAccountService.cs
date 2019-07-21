using Chilicki.Cantor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Domain.Services.Charges.Base
{
    public interface IChargeAccountService
    {
        User ChargeUserAccount(User user, decimal amount);
    }
}
